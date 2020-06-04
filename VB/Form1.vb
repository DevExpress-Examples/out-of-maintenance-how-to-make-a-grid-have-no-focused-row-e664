Imports System
Imports System.Data
Imports System.Linq
Imports System.Windows.Forms
Imports DevExpress.Skins
Imports DevExpress.XtraEditors

Namespace NoFocusedRow
    Partial Public Class Form1
        Inherits XtraForm

        Public Sub New()
            InitializeComponent()
        End Sub

        Protected Overrides Sub OnShown(e As EventArgs)
            MyBase.OnShown(e)
            gridView1.FocusInvalidRow()
        End Sub
        Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            gridControl1.DataSource = GetData()
        End Sub

        Private Function GetData() As DataTable
            Dim table As New DataTable()
            table.Columns.Add("ID", GetType(Integer))
            table.Columns.Add("ItemName")
            For i As Integer = 1 To 5
                table.Rows.Add(New Object() {i, "Item " & i.ToString()})
            Next i
            table.AcceptChanges()
            Return table
        End Function
    End Class
End Namespace
