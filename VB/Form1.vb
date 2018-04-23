Imports System
Imports System.Data
Imports System.Linq
Imports System.Windows.Forms

Namespace NoFocusedRow
	Partial Public Class Form1
		Inherits Form

		Private focusedRowHelper As GridFocusedRowHighlightHelper

		Public Sub New()
			InitializeComponent()
			focusedRowHelper = New GridFocusedRowHighlightHelper(gridView1)
		End Sub

		Protected Overrides Sub OnFormClosing(ByVal e As FormClosingEventArgs)
			MyBase.OnFormClosing(e)
			focusedRowHelper.Deactivate()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
			gridControl1.DataSource = GetData()
		End Sub

		Private Function GetData() As DataTable
			Dim table As New DataTable()
			table.Columns.Add("ID", GetType(Integer))
			table.Columns.Add("ItemName")
			For i As Integer = 1 To 5
				table.Rows.Add(New Object() { i, "Item " & i.ToString() })
			Next i
			table.AcceptChanges()
			Return table
		End Function
	End Class
End Namespace
