VERSION 5.00
Begin VB.Form InterestCalculator 
   Caption         =   "Interest Calculator"
   ClientHeight    =   4080
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   4680
   LinkTopic       =   "Form1"
   ScaleHeight     =   4080
   ScaleWidth      =   4680
   StartUpPosition =   3  'Windows Default
   Begin VB.TextBox Interest 
      Enabled         =   0   'False
      Height          =   495
      Left            =   2400
      TabIndex        =   0
      Top             =   2400
      Width           =   1215
   End
   Begin VB.CommandButton CommandExit 
      Caption         =   "E&xit"
      Height          =   495
      Left            =   1800
      TabIndex        =   8
      Top             =   3240
      Width           =   1215
   End
   Begin VB.CommandButton CommandCalculateInterest 
      Caption         =   "&Calculate Interest"
      Height          =   495
      Left            =   360
      TabIndex        =   7
      Top             =   3240
      Width           =   1215
   End
   Begin VB.TextBox Principal 
      Height          =   375
      Left            =   2400
      TabIndex        =   1
      Top             =   120
      Width           =   1215
   End
   Begin VB.TextBox Term 
      Height          =   405
      Left            =   2400
      TabIndex        =   5
      Top             =   1560
      Width           =   1215
   End
   Begin VB.TextBox Rate 
      Height          =   375
      Left            =   2400
      TabIndex        =   4
      Top             =   840
      Width           =   1215
   End
   Begin VB.Label LabelInterest 
      Caption         =   "Interest:"
      Height          =   255
      Left            =   360
      TabIndex        =   9
      Top             =   2520
      Width           =   735
   End
   Begin VB.Label Label2 
      Caption         =   "Principal:"
      Height          =   255
      Left            =   360
      TabIndex        =   6
      Top             =   240
      Width           =   1215
   End
   Begin VB.Label LabelTermAnnualPeriods 
      Caption         =   "&Term (annual periods):"
      Height          =   255
      Left            =   360
      TabIndex        =   3
      Top             =   1680
      Width           =   1695
   End
   Begin VB.Label LabelInterestRate 
      Caption         =   "Interest Rate (8 for 8%):"
      Height          =   255
      Left            =   360
      TabIndex        =   2
      Top             =   840
      Width           =   1695
   End
End
Attribute VB_Name = "InterestCalculator"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub CommandCalculateInterest_Click()
 Dim Principal As Double
 Dim Rate As Double
 Dim Term As Double
 Principal = Val(InterestCalculator.Principal.Text)
 Rate = Val(InterestCalculator.Rate.Text)
 Term = Val(InterestCalculator.Term.Text)
 InterestCalculator.Interest.Text = Principal * Rate * Term / 100
End Sub

Private Sub CommandExit_Click()
 Unload InterestCalculator
 End
End Sub

