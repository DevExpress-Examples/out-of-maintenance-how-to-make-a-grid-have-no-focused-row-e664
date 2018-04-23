Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports System
Imports System.Linq

Namespace NoFocusedRow
	Public Class GridFocusedRowHighlightHelper
		Private _view As GridView = Nothing
		Private prevFocusRectStyle As DrawFocusRectStyle
		Private IsFocusedRowHighlighted As Boolean = True
		Public Property ShowIndicationOnFirstClick() As Boolean

		Public Sub New(ByVal view As GridView)
			_view = view
			ShowIndicationOnFirstClick = True
			Activate()
			SetFocusedRowIndication(False)
		End Sub

		Public Sub SetFocusedRowIndication(ByVal highlight As Boolean)
			IsFocusedRowHighlighted = highlight
			If Not highlight Then
				prevFocusRectStyle = _view.FocusRectStyle
			End If
			_view.BeginUpdate()
			_view.FocusRectStyle = If(highlight, prevFocusRectStyle, DrawFocusRectStyle.None)
			_view.OptionsSelection.EnableAppearanceFocusedCell = IsFocusedRowHighlighted
			_view.OptionsSelection.EnableAppearanceFocusedRow = IsFocusedRowHighlighted
			_view.OptionsSelection.EnableAppearanceHideSelection = IsFocusedRowHighlighted
            '_view.OptionsView.ShowIndicator = IsFocusedRowHighlighted
            _view.EndUpdate()
		End Sub

		Private Sub _view_CustomDrawRowIndicator(ByVal sender As Object, ByVal e As RowIndicatorCustomDrawEventArgs)
			If Not IsFocusedRowHighlighted Then
				e.Info.ImageIndex = -1
			End If
		End Sub

		Private Sub View_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
			If ShowIndicationOnFirstClick Then
				Dim hi As GridHitInfo = _view.CalcHitInfo(e.Location)
				If hi.InRow Then
					SetFocusedRowIndication(True)
				End If
			End If
		End Sub

		Public Sub Deactivate()
			SetFocusedRowIndication(True)
			RemoveHandler _view.MouseDown, AddressOf View_MouseDown
			RemoveHandler _view.CustomDrawRowIndicator, AddressOf _view_CustomDrawRowIndicator
		End Sub

		Public Sub Activate()
			AddHandler _view.MouseDown, AddressOf View_MouseDown
			AddHandler _view.CustomDrawRowIndicator, AddressOf _view_CustomDrawRowIndicator
		End Sub
	End Class
End Namespace
