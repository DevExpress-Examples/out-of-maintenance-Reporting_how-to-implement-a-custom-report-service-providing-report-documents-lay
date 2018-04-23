Imports Microsoft.VisualBasic
Imports System
Namespace ClientApp
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Me.printingSystem1 = New DevExpress.XtraPrinting.PrintingSystem(Me.components)
			Me.comboBox1 = New System.Windows.Forms.ComboBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.button1 = New System.Windows.Forms.Button()
			Me.button2 = New System.Windows.Forms.Button()
			CType(Me.printingSystem1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' comboBox1
			' 
			Me.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.comboBox1.FormattingEnabled = True
			Me.comboBox1.Location = New System.Drawing.Point(123, 71)
			Me.comboBox1.Name = "comboBox1"
			Me.comboBox1.Size = New System.Drawing.Size(212, 24)
			Me.comboBox1.TabIndex = 0
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(12, 74)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(105, 17)
			Me.label1.TabIndex = 1
			Me.label1.Text = "Select a report:"
			' 
			' button1
			' 
			Me.button1.Location = New System.Drawing.Point(15, 21)
			Me.button1.Name = "button1"
			Me.button1.Size = New System.Drawing.Size(320, 30)
			Me.button1.TabIndex = 2
			Me.button1.Text = "Refresh reports list"
			Me.button1.UseVisualStyleBackColor = True
'			Me.button1.Click += New System.EventHandler(Me.button1_Click);
			' 
			' button2
			' 
			Me.button2.Location = New System.Drawing.Point(15, 119)
			Me.button2.Name = "button2"
			Me.button2.Size = New System.Drawing.Size(320, 30)
			Me.button2.TabIndex = 3
			Me.button2.Text = "Show a report"
			Me.button2.UseVisualStyleBackColor = True
'			Me.button2.Click += New System.EventHandler(Me.button2_Click);
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(8F, 16F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(353, 175)
			Me.Controls.Add(Me.button2)
			Me.Controls.Add(Me.button1)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.comboBox1)
			Me.Name = "Form1"
			Me.Text = "Form1"
			CType(Me.printingSystem1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private printingSystem1 As DevExpress.XtraPrinting.PrintingSystem
		Private comboBox1 As System.Windows.Forms.ComboBox
		Private label1 As System.Windows.Forms.Label
		Private WithEvents button1 As System.Windows.Forms.Button
		Private WithEvents button2 As System.Windows.Forms.Button
	End Class
End Namespace

