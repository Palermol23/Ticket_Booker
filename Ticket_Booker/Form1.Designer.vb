<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.startPurchase = New System.Windows.Forms.Button()
        Me.purchaseDisplay = New System.Windows.Forms.ListView()
        Me.Position = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me._Class = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Price = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.totalPriceLabel = New System.Windows.Forms.Label()
        Me.sDInputBox = New System.Windows.Forms.GroupBox()
        Me.preferenceSet = New System.Windows.Forms.Button()
        Me.M2Label = New System.Windows.Forms.Label()
        Me.areaPerPersonInput = New System.Windows.Forms.NumericUpDown()
        Me.socialDistancingCheck = New System.Windows.Forms.CheckBox()
        Me.capacityLabel = New System.Windows.Forms.Label()
        Me.venueDetailBox = New System.Windows.Forms.RichTextBox()
        Me.seatPickNumberInput = New System.Windows.Forms.NumericUpDown()
        Me.autoButton = New System.Windows.Forms.Button()
        Me.nameLabel = New System.Windows.Forms.Label()
        Me.nameInput = New System.Windows.Forms.TextBox()
        Me.mobileLabel = New System.Windows.Forms.Label()
        Me.mobileInput = New System.Windows.Forms.TextBox()
        Me.purchaseBox = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.sDInputBox.SuspendLayout()
        CType(Me.areaPerPersonInput, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.seatPickNumberInput, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.purchaseBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'startPurchase
        '
        Me.startPurchase.Enabled = False
        Me.startPurchase.Font = New System.Drawing.Font("Microsoft Sans Serif", 17.875!)
        Me.startPurchase.Location = New System.Drawing.Point(20, 19)
        Me.startPurchase.Name = "startPurchase"
        Me.startPurchase.Size = New System.Drawing.Size(134, 51)
        Me.startPurchase.TabIndex = 0
        Me.startPurchase.Text = "Purchase"
        Me.startPurchase.UseVisualStyleBackColor = True
        '
        'purchaseDisplay
        '
        Me.purchaseDisplay.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.purchaseDisplay.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Position, Me._Class, Me.Price})
        Me.purchaseDisplay.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.purchaseDisplay.HideSelection = False
        Me.purchaseDisplay.LabelWrap = False
        Me.purchaseDisplay.Location = New System.Drawing.Point(1614, 6)
        Me.purchaseDisplay.Margin = New System.Windows.Forms.Padding(2)
        Me.purchaseDisplay.MinimumSize = New System.Drawing.Size(286, 168)
        Me.purchaseDisplay.Name = "purchaseDisplay"
        Me.purchaseDisplay.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.purchaseDisplay.Size = New System.Drawing.Size(286, 168)
        Me.purchaseDisplay.TabIndex = 4
        Me.purchaseDisplay.UseCompatibleStateImageBehavior = False
        Me.purchaseDisplay.View = System.Windows.Forms.View.Details
        '
        'Position
        '
        Me.Position.Text = "Seat"
        Me.Position.Width = 156
        '
        '_Class
        '
        Me._Class.Text = "Class"
        Me._Class.Width = 207
        '
        'Price
        '
        Me.Price.Text = "Price"
        Me.Price.Width = 200
        '
        'totalPriceLabel
        '
        Me.totalPriceLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.totalPriceLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.totalPriceLabel.Location = New System.Drawing.Point(1612, 186)
        Me.totalPriceLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.totalPriceLabel.Name = "totalPriceLabel"
        Me.totalPriceLabel.Size = New System.Drawing.Size(140, 22)
        Me.totalPriceLabel.TabIndex = 5
        Me.totalPriceLabel.Text = "Bruh"
        '
        'sDInputBox
        '
        Me.sDInputBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sDInputBox.Controls.Add(Me.preferenceSet)
        Me.sDInputBox.Controls.Add(Me.M2Label)
        Me.sDInputBox.Controls.Add(Me.areaPerPersonInput)
        Me.sDInputBox.Controls.Add(Me.socialDistancingCheck)
        Me.sDInputBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.75!)
        Me.sDInputBox.Location = New System.Drawing.Point(636, 608)
        Me.sDInputBox.Margin = New System.Windows.Forms.Padding(2)
        Me.sDInputBox.Name = "sDInputBox"
        Me.sDInputBox.Padding = New System.Windows.Forms.Padding(2)
        Me.sDInputBox.Size = New System.Drawing.Size(506, 300)
        Me.sDInputBox.TabIndex = 6
        Me.sDInputBox.TabStop = False
        Me.sDInputBox.Text = "Social Distancing"
        '
        'preferenceSet
        '
        Me.preferenceSet.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.preferenceSet.Location = New System.Drawing.Point(12, 199)
        Me.preferenceSet.Margin = New System.Windows.Forms.Padding(2)
        Me.preferenceSet.Name = "preferenceSet"
        Me.preferenceSet.Size = New System.Drawing.Size(476, 85)
        Me.preferenceSet.TabIndex = 3
        Me.preferenceSet.Text = "Set Preferences"
        Me.preferenceSet.UseVisualStyleBackColor = True
        '
        'M2Label
        '
        Me.M2Label.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.M2Label.AutoSize = True
        Me.M2Label.Location = New System.Drawing.Point(136, 149)
        Me.M2Label.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.M2Label.Name = "M2Label"
        Me.M2Label.Size = New System.Drawing.Size(309, 47)
        Me.M2Label.TabIndex = 2
        Me.M2Label.Text = "M^2 per Person"
        '
        'areaPerPersonInput
        '
        Me.areaPerPersonInput.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.areaPerPersonInput.Enabled = False
        Me.areaPerPersonInput.Location = New System.Drawing.Point(12, 148)
        Me.areaPerPersonInput.Margin = New System.Windows.Forms.Padding(2)
        Me.areaPerPersonInput.Name = "areaPerPersonInput"
        Me.areaPerPersonInput.Size = New System.Drawing.Size(107, 54)
        Me.areaPerPersonInput.TabIndex = 1
        Me.areaPerPersonInput.Value = New Decimal(New Integer() {4, 0, 0, 0})
        '
        'socialDistancingCheck
        '
        Me.socialDistancingCheck.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.socialDistancingCheck.Location = New System.Drawing.Point(12, 48)
        Me.socialDistancingCheck.Margin = New System.Windows.Forms.Padding(2)
        Me.socialDistancingCheck.Name = "socialDistancingCheck"
        Me.socialDistancingCheck.Size = New System.Drawing.Size(491, 78)
        Me.socialDistancingCheck.TabIndex = 0
        Me.socialDistancingCheck.Text = "Enable Social Distancing"
        Me.socialDistancingCheck.UseVisualStyleBackColor = True
        '
        'capacityLabel
        '
        Me.capacityLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.capacityLabel.AutoSize = True
        Me.capacityLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 17.875!)
        Me.capacityLabel.Location = New System.Drawing.Point(1451, 506)
        Me.capacityLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.capacityLabel.Name = "capacityLabel"
        Me.capacityLabel.Size = New System.Drawing.Size(239, 29)
        Me.capacityLabel.TabIndex = 8
        Me.capacityLabel.Text = "Capacity Remaining: "
        Me.capacityLabel.Visible = False
        '
        'venueDetailBox
        '
        Me.venueDetailBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.venueDetailBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 25.875!)
        Me.venueDetailBox.Location = New System.Drawing.Point(1369, 1108)
        Me.venueDetailBox.Margin = New System.Windows.Forms.Padding(2)
        Me.venueDetailBox.Name = "venueDetailBox"
        Me.venueDetailBox.ReadOnly = True
        Me.venueDetailBox.Size = New System.Drawing.Size(284, 195)
        Me.venueDetailBox.TabIndex = 9
        Me.venueDetailBox.Text = ""
        '
        'seatPickNumberInput
        '
        Me.seatPickNumberInput.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.seatPickNumberInput.Enabled = False
        Me.seatPickNumberInput.Font = New System.Drawing.Font("Microsoft Sans Serif", 17.875!)
        Me.seatPickNumberInput.Location = New System.Drawing.Point(1798, 176)
        Me.seatPickNumberInput.Margin = New System.Windows.Forms.Padding(2)
        Me.seatPickNumberInput.Name = "seatPickNumberInput"
        Me.seatPickNumberInput.Size = New System.Drawing.Size(100, 34)
        Me.seatPickNumberInput.TabIndex = 10
        '
        'autoButton
        '
        Me.autoButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.autoButton.Enabled = False
        Me.autoButton.Location = New System.Drawing.Point(1721, 176)
        Me.autoButton.Margin = New System.Windows.Forms.Padding(2)
        Me.autoButton.Name = "autoButton"
        Me.autoButton.Size = New System.Drawing.Size(74, 32)
        Me.autoButton.TabIndex = 11
        Me.autoButton.Text = "Pick Seats Automatically"
        Me.autoButton.UseVisualStyleBackColor = True
        '
        'nameLabel
        '
        Me.nameLabel.AutoSize = True
        Me.nameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.875!)
        Me.nameLabel.Location = New System.Drawing.Point(154, 22)
        Me.nameLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.nameLabel.Name = "nameLabel"
        Me.nameLabel.Size = New System.Drawing.Size(62, 22)
        Me.nameLabel.TabIndex = 12
        Me.nameLabel.Text = "Name:"
        '
        'nameInput
        '
        Me.nameInput.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.875!)
        Me.nameInput.Location = New System.Drawing.Point(225, 17)
        Me.nameInput.Margin = New System.Windows.Forms.Padding(2)
        Me.nameInput.Name = "nameInput"
        Me.nameInput.Size = New System.Drawing.Size(134, 27)
        Me.nameInput.TabIndex = 13
        '
        'mobileLabel
        '
        Me.mobileLabel.AutoSize = True
        Me.mobileLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.875!)
        Me.mobileLabel.Location = New System.Drawing.Point(154, 53)
        Me.mobileLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.mobileLabel.Name = "mobileLabel"
        Me.mobileLabel.Size = New System.Drawing.Size(67, 22)
        Me.mobileLabel.TabIndex = 14
        Me.mobileLabel.Text = "Mobile:"
        '
        'mobileInput
        '
        Me.mobileInput.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.875!)
        Me.mobileInput.Location = New System.Drawing.Point(225, 48)
        Me.mobileInput.Margin = New System.Windows.Forms.Padding(2)
        Me.mobileInput.Name = "mobileInput"
        Me.mobileInput.Size = New System.Drawing.Size(134, 27)
        Me.mobileInput.TabIndex = 15
        '
        'purchaseBox
        '
        Me.purchaseBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.purchaseBox.Controls.Add(Me.startPurchase)
        Me.purchaseBox.Controls.Add(Me.mobileInput)
        Me.purchaseBox.Controls.Add(Me.nameLabel)
        Me.purchaseBox.Controls.Add(Me.nameInput)
        Me.purchaseBox.Controls.Add(Me.mobileLabel)
        Me.purchaseBox.Location = New System.Drawing.Point(1118, 243)
        Me.purchaseBox.Name = "purchaseBox"
        Me.purchaseBox.Size = New System.Drawing.Size(513, 89)
        Me.purchaseBox.TabIndex = 16
        Me.purchaseBox.TabStop = False
        Me.purchaseBox.Text = "Purchase"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 58.25!)
        Me.Label1.Location = New System.Drawing.Point(11, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1203, 89)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Seat™ Booker™ Thing™ I™ Made™"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1904, 1548)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.autoButton)
        Me.Controls.Add(Me.seatPickNumberInput)
        Me.Controls.Add(Me.sDInputBox)
        Me.Controls.Add(Me.totalPriceLabel)
        Me.Controls.Add(Me.purchaseDisplay)
        Me.Controls.Add(Me.capacityLabel)
        Me.Controls.Add(Me.venueDetailBox)
        Me.Controls.Add(Me.purchaseBox)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.sDInputBox.ResumeLayout(False)
        Me.sDInputBox.PerformLayout()
        CType(Me.areaPerPersonInput, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.seatPickNumberInput, System.ComponentModel.ISupportInitialize).EndInit()
        Me.purchaseBox.ResumeLayout(False)
        Me.purchaseBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents startPurchase As Button
    Friend WithEvents purchaseDisplay As ListView
    Friend WithEvents Position As ColumnHeader
    Friend WithEvents _Class As ColumnHeader
    Friend WithEvents Price As ColumnHeader
    Friend WithEvents totalPriceLabel As Label
    Friend WithEvents sDInputBox As GroupBox
    Friend WithEvents M2Label As Label
    Friend WithEvents areaPerPersonInput As NumericUpDown
    Friend WithEvents socialDistancingCheck As CheckBox
    Friend WithEvents preferenceSet As Button
    Friend WithEvents capacityLabel As Label
    Friend WithEvents venueDetailBox As RichTextBox
    Friend WithEvents seatPickNumberInput As NumericUpDown
    Friend WithEvents autoButton As Button
    Friend WithEvents nameLabel As Label
    Friend WithEvents nameInput As TextBox
    Friend WithEvents mobileLabel As Label
    Friend WithEvents mobileInput As TextBox
    Friend WithEvents purchaseBox As GroupBox
    Friend WithEvents Label1 As Label
End Class
