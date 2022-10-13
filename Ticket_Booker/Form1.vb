Public Class Form1
    Dim seatGrid As seat(,) 'Makes seatgrid global to all subroutines in form1
    'These variables are dedicated to saving files to ram, these ones specifically save the filepaths
    Dim baseFilePath As String = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\Documents\SeatBookerLogFiles\"
    Dim baseFile As String = "CapitolTheatre-1.txt"
    Dim statusFile As String = "SeatStatus.txt"
    Dim logFile As String = "PurchaseLog.txt"
    Dim fullFileBase As String() 'these variables contain the actual files
    Dim fullFileStatusBlock As Char(,) 'Store the states of the seats based on if they are purchased and if they are blocked by social distancing
    Dim fullFileStatusSocial As Char(,)
    Dim fullFilePurchaseLog As String()
    Dim enableSocialDistancing As Boolean 'if we are considering Social distancing
    Dim minimumAreaPerPerson As Integer
    Dim occupiedSeatNumber As Integer
    Dim updateFile As Boolean = False
    Dim purchaseList As New List(Of seat) 'list of seats sellected for purchace
    Dim totalPrice As Integer
    'Venue info from the file
    Dim company As String
    Dim theatre As String
    Dim venueCapacity As Integer
    Dim startTime As Integer
    Dim finishTime As Integer
    Dim basePrice As Integer
    'Subroutines in Form1 have been rough order of execution
    'and categorised around when they are called from the perspective of Begin()
    'Which is responsible for loading the program and files
    'Pre-Begin()
    Public Sub readFailureManager() Handles Me.Load
        If Not System.IO.File.Exists(baseFilePath + baseFile) Or Not System.IO.File.Exists(baseFilePath + statusFile) Or Not System.IO.File.Exists(baseFilePath + logFile) Then 'if any file is missing...
            Dim result As DialogResult = MessageBox.Show("Something occured that prevented a file from opening properly, do you want to generate a default one?", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
            If result = DialogResult.OK Then
                If Not System.IO.File.Exists(baseFilePath + baseFile) Then 'download base file if missing
                    My.Computer.Network.DownloadFile("https://cdn.discordapp.com/attachments/758961474403041302/1001342660981817425/CapitolTheatre-1.txt", baseFilePath + baseFile)
                End If
                If Not System.IO.File.Exists(baseFilePath + statusFile) Then 'download status file if missing
                    My.Computer.Network.DownloadFile("https://cdn.discordapp.com/attachments/758961474403041302/1001438228546605127/SeatStatus.txt", baseFilePath + statusFile)
                End If
                If Not System.IO.File.Exists(baseFilePath + logFile) Then 'download log file if missing
                    My.Computer.Network.DownloadFile("https://cdn.discordapp.com/attachments/758961474403041302/1001343516590473307/PurchaseLogExample.txt", baseFilePath + logFile)
                End If
            Else
                Application.Exit()
            End If
        End If
    End Sub 'attempts to fix a read failure
    Private Sub Form1_Formating_Fix() Handles Me.Shown 'on start
        Location = New Point(0, 0)
        Size = New Size(1920, 1080)
        purchaseDisplay.Size = New Size(568, 319)
        purchaseDisplay.Location = New Point(1324, 12)
        totalPriceLabel.Size = New Size(281, 42)
        totalPriceLabel.Location = New Point(1319, 358)
        sDInputBox.Location = New Point(418, 211)
        sDInputBox.Size = New Size(1012, 576)
        socialDistancingCheck.Location = New Point(24, 92)
        socialDistancingCheck.Size = New Size(982, 150)
        areaPerPersonInput.Location = New Point(25, 284)
        areaPerPersonInput.Size = New Size(214, 54)
        M2Label.Location = New Point(306, 286)
        M2Label.Size = New Size(309, 47)
        preferenceSet.Size = New Size(951, 163)
        preferenceSet.Location = New Point(25, 383)
        capacityLabel.Location = New Point(1311, 456)
        capacityLabel.Size = New Size(480, 55)
        venueDetailBox.Location = New Point(1311, 537)
        venueDetailBox.Size = New Size(563, 471)
        seatPickNumberInput.Location = New Point(1538 + 148, 338 + (62 / 4))
        seatPickNumberInput.Size = New Size(200, 61)
        autoButton.Location = New Point(1538, 338)
        autoButton.Size = New Size(148, 62)
        'purchase ui
        startPurchase.Location = New Point(20, 19)
        startPurchase.Size = New Size(134, 51)
        nameLabel.Location = New Point(154, 22)
        nameLabel.Size = New Size(120, 39)
        nameInput.Location = New Point(225, 17)
        nameInput.Size = New Size(264, 46)
        mobileLabel.Location = New Point(154, 53)
        mobileLabel.Size = New Size(129, 39)
        mobileInput.Location = New Point(225, 48)
        mobileInput.Size = New Size(264, 46)
        purchaseBox.Location = New Point(1324, 12 + 319 + 75)
    End Sub 'The form designer does not work so I need to set sizes and positions manually
    Private Sub socialDistancingCheck_CheckedChanged(sender As Object, e As EventArgs) Handles socialDistancingCheck.CheckedChanged
        areaPerPersonInput.Enabled = sender.checked
    End Sub 'toggles whether or not social distancing is accounted for
    Private Sub preferenceSet_Click(sender As Object, e As EventArgs) Handles preferenceSet.Click
        enableSocialDistancing = socialDistancingCheck.Checked 'saves preferences
        minimumAreaPerPerson = areaPerPersonInput.Value
        capacityLabel.Visible = socialDistancingCheck.Checked
        sDInputBox.Enabled = False
        sDInputBox.Visible = False
        startPurchase.Enabled = True
        Begin()
    End Sub 'saves preferences when button is pressed, then loads program
    Private Sub Begin()
        fullFileBase = readFile(baseFilePath + baseFile) 'gets the whole file
        fullFilePurchaseLog = readFile(baseFilePath + logFile)
        Dim testSeatMap(,) As Char = getSeatMap(10, fullFileBase) 'gets the seat map (Disambiguation: Seat map is the 2d grid of CHARS only relevant in the begin subroutine)
        Dim tempFileStatus As String() = readFile(baseFilePath + statusFile) 'gets the seat status map
        Dim maxMapLength As Integer = tempFileStatus(1).Length 'gets the max length of a row (the top row)
        Dim tempFileStatusBlock((tempFileStatus.Length - 2) / 2 - 2, maxMapLength - 1) As Char 'makes the temporary arrays of the seat states
        Dim tempFileStatusSocial((tempFileStatus.Length - 2) / 2 - 2, maxMapLength - 1) As Char
        For i = 0 To tempFileStatusBlock.GetLength(0) - 1 'puts the states in the block array
            Dim tempchar As Char() = tempFileStatus(i).ToCharArray()
            For j = 0 To maxMapLength - 1
                tempFileStatusBlock(i, j) = tempchar(j)
            Next
        Next
        For i = 0 To tempFileStatusSocial.GetLength(0) - 1 'puts the states in the social distance array
            Dim tempchar As Char() = tempFileStatus(i + 1 + tempFileStatusBlock.GetLength(0)).ToCharArray()
            For j = 0 To maxMapLength - 1
                tempFileStatusSocial(i, j) = tempchar(j)
            Next
        Next
        fullFileStatusBlock = tempFileStatusBlock 'puts the temporary arrays in the global variables
        fullFileStatusSocial = tempFileStatusSocial
        'gets the venue information from the file
        company = getVenueData("Company: ", fullFileBase(0), 0)
        theatre = getVenueData("Theatre: ", fullFileBase(1), 0)
        venueCapacity = Math.Floor(Int(getVenueData("Total Area: ", fullFileBase(2), 3)) / minimumAreaPerPerson)
        startTime = Convert.ToInt32(getVenueData("Start Time: ", fullFileBase(3), 0))
        finishTime = Convert.ToInt32(getVenueData("Finish Time: ", fullFileBase(4), 0))
        basePrice = Convert.ToInt32(getVenueData("Base Seat Price: ", fullFileBase(6), 0))
        generateSeats(testSeatMap.GetLength(0), testSeatMap.GetLength(1) - 1, 200, 200, 50, 50, testSeatMap, fullFileStatusBlock, fullFileStatusSocial, 5) 'generate the button grid
        capacityLabel.Text = "Capacity Remaining: " + Str(venueCapacity - occupiedSeatNumber)
        For i = 0 To 6
            venueDetailBox.AppendText(fullFileBase(i) + vbNewLine)
        Next
        updateFile = True
        If venueCapacity - occupiedSeatNumber > 0 Then
            seatPickNumberInput.Enabled = True
            autoButton.Enabled = True
            seatPickNumberInput.Maximum = venueCapacity - occupiedSeatNumber
        End If
    End Sub 'Loads the program and fills critical variables
    'Intra-Begin()
    Public Function readFile(filePath As String) As String()
        Dim output As String()
        If System.IO.File.Exists(filePath) Then 'ensures if file exists
            Dim objReader As New System.IO.StreamReader(filePath)
            Dim counter As Integer = 0
            Dim textLine As String
            Try
                textLine = objReader.ReadLine() 'first pass to count lines
                Do While textLine <> "***zzz***"
                    counter = counter + 1
                    textLine = objReader.ReadLine()
                Loop
                objReader.BaseStream.Position = 0
                Dim outputTemp(counter - 1) As String
                counter = 0
                If filePath = baseFilePath + statusFile Then 'for some reason the status file will NOT be used correctly if i do not do this so bruh
                    textLine = objReader.ReadLine()
                End If
                textLine = objReader.ReadLine() 'second pass to actually save file to ram
                If textLine = "" Then 'ensures that there
                    textLine = objReader.ReadLine()
                End If
                Do While textLine <> "***zzz***"
                    outputTemp(counter) = textLine
                    counter = counter + 1
                    textLine = objReader.ReadLine()
                Loop
                objReader.Close()
                output = outputTemp
            Catch ex As Exception
                MessageBox.Show("it brokey")
                readFailureManager()
            End Try
        Else
            readFailureManager()
        End If
#Disable Warning BC42104 ' Variable is used before it has been assigned a value
        Return output
#Enable Warning BC42104 ' Variable is used before it has been assigned a value
    End Function 'reads the input filepath, returning it as an array of strings
    Public Function getSeatMap(startingFileIndex As Integer, file As String()) As Char(,)
        Dim outputx As Integer = file.Length - (10 + 1)
        Dim desiredSize As Integer = CSV_to_String(file(startingFileIndex), ",").Length
        Dim output(outputx, desiredSize) As Char
        For i = startingFileIndex To file.Length - 1
            Dim adjustString As String = CSV_to_String(file(i), ",")
            While desiredSize <> adjustString.Length 'should the next line not be the size of the biggest lint
                If desiredSize - adjustString.Length = 1 Then 'if the difference is 1 then
                    If adjustString.Length Mod 2 = 0 Then 'if the string length is even split the string in half and pad the middle
                        Dim tempcharnested As Char() = adjustString.ToCharArray
                        Dim front As String = ""
                        Dim back As String = ""
                        Dim substringLength As Integer = adjustString.Length / 2
                        For k = 0 To adjustString / 2 - 1
                            front = front + tempcharnested(k)
                        Next
                        For k = adjustString / 2 To adjustString - 1
                            back = back + tempcharnested(k)
                        Next
                        adjustString = front + "X" + back
                    Else 'otherwise just pad the end
                        adjustString = adjustString + "X"
                    End If
                ElseIf desiredSize - adjustString.Length > 1 Then 'if the difference is more than 1 pad front and end
                    adjustString = "X" + adjustString + "X"
                End If
            End While
            Dim tempchar As Char() = adjustString.ToCharArray
            For j = 0 To tempchar.Length - 1 'to stop vbnull char from entering the string
                output(i - startingFileIndex, j) = tempchar(j)
            Next
        Next
        Return output
    End Function 'gets the char array of the file and extracts the seats from it as a 2D char array
    Function getVenueData(removeInput As String, lineInput As String, endInput As Integer) As String
        Dim output As String = ""
        Dim tempCharRemove As Char() = removeInput.ToCharArray
        Dim tempCharLine As Char() = lineInput.ToCharArray
        For i = tempCharRemove.Length To tempCharLine.Length - 1 - endInput
            output = output + tempCharLine(i)
        Next
        Return output
    End Function 'Clips the venue information to get just the numbers as a string
    Public Sub generateSeats(newCollum As Integer, newRow As Integer, startX As Integer, startY As Integer, buttonHeight As Integer, buttonWidth As Integer, seatMap As Char(,), blockMap As Char(,), SocialMap As Char(,), spacing As Integer)
        Dim constX As Integer = startX 'saving original xy values before alteration
        Dim consty As Integer = startY
        Dim buttonTemplate(newCollum - 1, newRow - 1) As seat 'makes a template of the seats in an array
        Dim tempBlock As Boolean = False 'starter boolean for blocks and social distancing
        Dim tempSocial As Boolean = False
        Dim nameCounterLetter As Integer = 0
        Dim nameCounterNumber As Integer = 0
        Dim tempName As String
        Dim tempVenueCap As Integer = 0
        seatGrid = buttonTemplate 'makes the array global
        For i = 0 To newCollum - 1 'for every collum
            For j = 0 To newRow - 1 'for every row
                If seatMap(i, j) <> "_" And seatMap(i, j) <> "X" Then
                    tempVenueCap = tempVenueCap + 1
                End If
                If blockMap(i, j) = "B" Then 'is it taken in the block map? if so make the button reflect that
                    tempBlock = True
                    occupiedSeatNumber = occupiedSeatNumber + 1
                Else
                    tempBlock = False
                End If
                If SocialMap(i, j) = "B" And enableSocialDistancing Then 'is it taken in the social distancing map? if so make the button reflect that if social distancing is enabled
                    tempSocial = True
                Else
                    tempSocial = False
                End If
                tempName = Chr(Asc("A") + nameCounterLetter) + Str(nameCounterNumber)
                seatGrid(i, j) = New seat(seatMap(i, j), Me, startX, startY, buttonHeight, buttonWidth, i, j, tempBlock, tempSocial, tempName, basePrice)  'declare a new button
                If seatMap(i, j) <> "_" And seatMap(i, j) <> "X" Then
                    nameCounterNumber = nameCounterNumber + 1
                End If
                startX = startX + buttonWidth + spacing 'increment the position of the button
            Next
            nameCounterNumber = 0
            If seatMap(i, 0) <> "_" Then
                nameCounterLetter = nameCounterLetter + 1
            End If
            startY = startY + buttonHeight + spacing
            startX = constX
        Next
        If enableSocialDistancing = False Then
            venueCapacity = tempVenueCap
        End If
    End Sub 'uses a large number of variables to place the buttons in a grid on the form
    'Post-Begin()
    Public Sub seatSelection(sender As seat) 'used to select seats
        If sender.getBorder() = Color.Red Then 'marks seats as selected
            sender.setBorder(Color.White)
            purchaseList.Remove(sender) 'remove item from list
            purchaseDisplay.Items.Remove(purchaseDisplay.FindItemWithText(sender.getText()))
            totalPrice = totalPrice - sender.getPrice()
        Else
            sender.setBorder(Color.Red)
            purchaseList.Add(sender) 'adds seat to list
            purchaseDisplay.Items.Add(sender.getText()) 'put's seat data on list display
            purchaseDisplay.Items(purchaseDisplay.FindItemWithText(sender.getText()).Index).SubItems.Add(sender.getClass())
            purchaseDisplay.Items(purchaseDisplay.FindItemWithText(sender.getText()).Index).SubItems.Add(Str(sender.getPrice()))
            totalPrice = totalPrice + sender.getPrice()
        End If
        totalPriceLabel.Text = "Total: $" + Str(totalPrice)
    End Sub 'called by the button when clicked to toggle the selection and add it to the purchase list
    Private Sub purchaseSeats(sender As Object, e As EventArgs) Handles startPurchase.Click
        Dim mobileCheck As Boolean = False
        If mobileInput.Text.Length = 10 Then
            Try
                Dim throwawayInteger As Integer = Int(mobileInput.Text)
                mobileCheck = True
            Catch ex As Exception

            End Try
        End If 'checks if input is number and 10 chars long
        If purchaseList.Count <> 0 And nameInput.Text <> "" And mobileCheck Then
            If occupiedSeatNumber < venueCapacity Or enableSocialDistancing = False Then
                Dim tempSeatArray As seat() = purchaseList.ToArray
                occupiedSeatNumber = occupiedSeatNumber + tempSeatArray.Length
                Dim tempList As String = CSV_to_String(tempSeatArray(0).getText(), " ")
                For i = 1 To tempSeatArray.Length - 1
                    tempList = tempList + ", " + CSV_to_String(tempSeatArray(i).getText(), " ")

                Next
                Dim tempLog(fullFilePurchaseLog.Length + 4) As String
                For i = 0 To tempSeatArray.Length - 1 'marks all selected seats as B in the bought map
                    fullFileStatusBlock(tempSeatArray(i).getArrayPosition(0), tempSeatArray(i).getArrayPosition(1)) = "B"
                    fullFileStatusSocial(tempSeatArray(i).getArrayPosition(0), tempSeatArray(i).getArrayPosition(1)) = "A"
                    tempSeatArray(i).setBlocked(True)
                    tempSeatArray(i).updateButton()
                    purchaseDisplay.Items.Remove(purchaseDisplay.FindItemWithText(tempSeatArray(i).getText()))
                Next
                For i = 0 To tempSeatArray.Length - 1 'marks all seats adjacent to selected seats as B in the block map
                    Dim D0 As Integer = tempSeatArray(i).getArrayPosition(0)
                    Dim D1 As Integer = tempSeatArray(i).getArrayPosition(1)
                    If D0 - 1 > -1 Then 'checks seats if they are outside of the array before using them
                        checkSocialAndUpdate(D0 - 1, D1)
                    End If
                    If D0 + 1 < fullFileStatusSocial.GetLength(0) Then
                        checkSocialAndUpdate(D0 + 1, D1)
                    End If
                    If D1 - 1 > -1 Then
                        checkSocialAndUpdate(D0, D1 - 1)
                    End If
                    If D1 + 1 < fullFileStatusSocial.GetLength(1) Then
                        checkSocialAndUpdate(D0, D1 + 1)
                    End If
                Next
                purchaseList.Clear()
                tempLog(0) = "Name: " + nameInput.Text
                tempLog(1) = "Seats Purchased: " + tempList
                tempLog(2) = "Price Paid: " + Str(totalPrice)
                tempLog(3) = "Mobile Number: " + mobileInput.Text
                tempLog(4) = ""
                totalPrice = 0
                totalPriceLabel.Text = "Total: $0"
                capacityLabel.Text = "Capacity Remaining: " + Str(venueCapacity - occupiedSeatNumber)
                For i = 4 To tempLog.Length - 2
                    tempLog(i) = fullFilePurchaseLog(i - 4)
                Next
                Erase fullFilePurchaseLog
                fullFilePurchaseLog = tempLog
            Else
                Dim result As DialogResult = MessageBox.Show("Exceeds room capacity, choose a lower number", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error)
                MsgBox(enableSocialDistancing)
                If result = DialogResult.Cancel Then
                    Application.Exit()
                End If
            End If
        ElseIf purchaseList.Count = 0 Then
            MessageBox.Show("No Seats Chosen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf nameInput.Text = "" Then
            MessageBox.Show("No Name Input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf mobileCheck = False Then
            MessageBox.Show("Invalid Mobile Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub 'when the purchase button is clicked, it saves the booking in memory and blocks the seats from being purchased
    Private Sub checkSocialAndUpdate(D0 As Integer, D1 As Integer)
        If fullFileStatusSocial(D0, D1) = "A" And fullFileStatusBlock(D0, D1) <> "B" Then 'checks if the seats are marked as A
            fullFileStatusSocial(D0, D1) = "B" 'mark them as B
            If enableSocialDistancing Then 'Updates seat
                seatGrid(D0, D1).setSocialBlock(True)
                seatGrid(D0, D1).updateButton()
            End If
        End If
    End Sub 'updates the appearance of a button
    Private Sub seatPickerAlgorithm(sender As Object, e As EventArgs) Handles autoButton.Click
        Dim tempseatarray As seat() = purchaseList.ToArray
        For i = 0 To tempseatarray.Length - 1 'clears previous selection
            seatSelection(tempseatarray(i))
        Next
        If seatPickNumberInput.Value <> 0 Then
            Dim seatsRequested As Integer = seatPickNumberInput.Value
            Dim Direction As Integer = -1
            Dim Start As Integer = seatGrid.GetLength(1) - 1
            Dim Finish As Integer = 0
            Dim i As Integer = seatGrid.GetLength(0) - 1
            Do While seatsRequested > 0
                For j = Start To Finish Step Direction
                    If seatGrid(i, j).getClass() <> "X" And seatGrid(i, j).getClass <> "_" And seatGrid(i, j).getBlocked = False And seatGrid(i, j).getSocialBlock = False And seatsRequested > 0 Then
                        seatSelection(seatGrid(i, j))
                        seatsRequested = seatsRequested - 1
                    End If
                Next
                Direction = -Direction 'for loop reverses direction, to snake in zigzag patern
                Dim tempStart As Integer = Start
                Start = Finish
                Finish = tempStart
                i = i - 1
            Loop
        Else
            MessageBox.Show("Input a value above 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub 'automatically picks seats given a valid number
    'End Of Program
    Private Sub autoSave() Handles Me.Closing
        If updateFile Then
            Dim objWriterStatus As New System.IO.StreamWriter(baseFilePath + statusFile)
            objWriterStatus.WriteLine("blockMap:" + objWriterStatus.NewLine)
            For i = 0 To fullFileStatusBlock.GetLength(0) - 1
                For j = 0 To fullFileStatusBlock.GetLength(1) - 2
                    objWriterStatus.Write(fullFileStatusBlock(i, j))
                Next
                objWriterStatus.WriteLine(fullFileStatusBlock(i, fullFileStatusBlock.GetLength(1) - 1))
            Next
            objWriterStatus.WriteLine("socialMap:")
            For i = 0 To fullFileStatusSocial.GetLength(0) - 1
                For j = 0 To fullFileStatusSocial.GetLength(1) - 2
                    objWriterStatus.Write(fullFileStatusSocial(i, j))
                Next
                objWriterStatus.WriteLine(fullFileStatusSocial(i, fullFileStatusSocial.GetLength(1) - 1))
            Next
            objWriterStatus.Write("***zzz***")
            objWriterStatus.Close()
            Dim objWriterLog As New System.IO.StreamWriter(baseFilePath + logFile)
            For i = 0 To fullFilePurchaseLog.Length - 1
                objWriterLog.Write(fullFilePurchaseLog(i) + objWriterLog.NewLine)
            Next
            objWriterLog.Write("***zzz***")
            objWriterLog.Close()
        End If
    End Sub 'Saves changes to memory to files on the closure of the application
    'Language Functions
    Function Split(Input As String, delim As String) As String()
        Dim CharArray() As Char = Input.ToArray()
        Dim Counter As Integer = 0
        Dim TempString As String = ""
        Dim OutputCounter As Integer = 1
        For i = 0 To CharArray.Length - 1
            If CharArray(i) = delim Then
                OutputCounter = OutputCounter + 1
            End If
        Next
        Dim OutputTemp(OutputCounter - 1) As String
        OutputCounter = 0
        Do Until Counter = CharArray.Length
            If CharArray(Counter) = delim And TempString <> "" Then
                OutputTemp(OutputCounter) = TempString
                TempString = ""
                OutputCounter = OutputCounter + 1
            Else
                TempString = TempString + CharArray(Counter)
            End If
            Counter = Counter + 1
        Loop
        OutputTemp(OutputTemp.Length - 1) = TempString
        Return OutputTemp
    End Function 'splits a string
    Function CSV_to_String(input As String, delim As String) As String 'removes a certain character from a string
        Dim CharArray() As Char = input.ToArray()
        Dim TempString As String = ""
        For i = 0 To CharArray.Length - 1
            If CharArray(i) <> delim Then
                TempString = TempString + CharArray(i)
            End If
        Next
        Return TempString
    End Function 'removes characters from a string
End Class
Public Class seat
    Private button As New Button
    Private basePrice As Integer
    Private seatClass As Char
    Private blocked As Boolean
    Private socialDistancing As Boolean
    Private price As Integer
    Private positionInArrayD0 As Integer
    Private positionInArrayD1 As Integer
    Private form As Form1
    'Main Methods
    Public Sub New(newType As Char, newForm As Form, startX As Integer, startY As Integer, buttonHeight As Integer, buttonWidth As Integer, posi As Integer, posj As Integer, block As Boolean, social As Boolean, newName As String, newBasePrice As Integer) 'sets type at the start
        seatClass = newType 'saves variables
        socialDistancing = block
        positionInArrayD0 = posi
        positionInArrayD1 = posj
        form = newForm
        blocked = block
        socialDistancing = social
        basePrice = newBasePrice

        With button
            If seatClass = "a" Then 'sets visual style and price of seats by type
                .BackColor = Color.Aqua
                .ForeColor = Color.Blue
                Me.price = basePrice * 1.5
            ElseIf seatClass = "b" Then
                .BackColor = Color.Green
                .ForeColor = Color.White
                Me.price = basePrice * 1
            ElseIf seatClass = "c" Then
                .BackColor = Color.Yellow
                .ForeColor = Color.DarkGoldenrod
                Me.price = basePrice * 0.8
            ElseIf seatClass = "d" Then
                .BackColor = Color.Orange
                .ForeColor = Color.White
                Me.price = basePrice * 0.6
            ElseIf seatClass = "e" Then
                .BackColor = Color.Red
                .ForeColor = Color.DarkRed
                Me.price = basePrice * 0.4
            ElseIf seatClass = "_" Then
                .BackColor = Color.Gray
                .ForeColor = Color.Black
                Me.price = basePrice * 1000
                .Enabled = False
            ElseIf seatClass = "X" Then
                'prevents end
            Else 'notifies if character it finds is incompatable
                MsgBox("Error: Unrecognised Seat Type: " + seatClass)
                Application.Exit()
            End If 'changes appearance of button and establishes price
            If socialDistancing Then 'changes appearance and makes button disabled when blocked or purchaced
                .Enabled = False
                .BackColor = Color.DarkGray
                .Text = "S"
            ElseIf blocked Then
                .Enabled = False
                .BackColor = Color.LightGray
                .Text = "N"
            Else
                .Text = Char.ToUpper(seatClass)
            End If
            .FlatStyle = FlatStyle.Flat 'add boarder
            .FlatAppearance.BorderColor = Color.White
            .FlatAppearance.BorderSize = 2
            .Width = buttonHeight 'add dimensions
            .Height = buttonWidth
            .Location = New Point(startX, startY) 'put button in location
            '.Name = Chr(Asc("A") + positionInArrayD0) + positionInArrayD1.ToString 'name button
            .Name = newName
            .Font = New Font(.Font.FontFamily, 9) 'resize font
            If seatClass = "_" Then 'labels isles
                .Text = "_"
            Else
                .Text = .Name
            End If
            If seatClass <> "X" Then 'stops buffer characters from appearing
                form.Controls.Add(button)
            End If

            AddHandler .Click, AddressOf buttonDoThing 'add it's handle

            'generate the button
        End With


    End Sub 'overloads the default seat constructor
    Public Sub buttonDoThing(Sender As Object, e As EventArgs)
        form.seatSelection(Me)
    End Sub 'calls seat selection
    Public Sub updateButton()
        With button
            .FlatAppearance.BorderColor = Color.White
            If socialDistancing Then
                .Enabled = False
                .BackColor = Color.DarkGray
            ElseIf blocked Then
                .Enabled = False
                .BackColor = Color.LightGray
            End If
        End With
    End Sub 'updates appearance

    'Accessors
    Public Function getClass() As Char
        Return seatClass
    End Function 'returns the class of the seat
    Public Function getBlocked() As Boolean
        Return blocked
    End Function 'returns if it is blocked for purchase
    Public Function getSocialBlock() As Boolean
        Return socialDistancing
    End Function 'returns if it is blocked for social distancing
    Public Function getPrice() As Integer
        Return price
    End Function 'returns the price of the seat
    Public Function getArrayPosition(dimension As Integer) As Integer
        If dimension = 0 Then
            Return positionInArrayD0
        ElseIf dimension = 1 Then
            Return positionInArrayD1
        Else
            Return -69
        End If
    End Function 'returns the position of the seat in the grid/array
    Public Function getName() As String
        Return button.Name
    End Function 'returns the name of the seat
    Public Function getText() As String
        Return button.Text
    End Function 'returns the text on the button
    Public Function getBorder() As Color
        Return button.FlatAppearance.BorderColor
    End Function 'returns the color of the border of the button
    'Mutators
    Public Sub setClass(newType As Char)
        seatClass = newType
    End Sub 'alters the class of the seat
    Public Sub setBlocked(newBlock As Boolean)
        blocked = newBlock
    End Sub 'alters it's status of being blocked for purchase
    Public Sub setSocialBlock(newBlock As Boolean)
        socialDistancing = newBlock
    End Sub 'alters it's status of being blocked for social distancing
    Public Sub setPrice(newPrice As Integer) 'probably not going to be used
        price = newPrice
    End Sub 'alters the price
    Public Sub setBorder(newColor As Color)
        button.FlatAppearance.BorderColor = newColor
    End Sub 'alters the color of the border of the button
End Class