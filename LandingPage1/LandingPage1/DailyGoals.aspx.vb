'Source credits:: https://codyhouse.co/demo/horizontal-timeline/index.html

Imports Newtonsoft.Json
'Public Class DailyGoal

'    Public Property DayLabel As String
'    Public Property DateValue As DateTime

'End Class

Public Class DailyGoals
    Inherits System.Web.UI.Page

    'Private Sub GetDailyGoals(ByVal jsonDailyGoalObj As String)
    '    Dim startDate As DateTime = DateTime.Today.AddDays(-21)
    '    Dim endDate As DateTime = DateTime.Today.AddDays(7)
    '    Dim dates As IEnumerable(Of DateTime) = Enumerable.Range(0, 1 + CInt((endDate - startDate).TotalDays)).Select(Function(n) startDate.AddDays(n)).ToArray()
    '    Const ListItemTemplate As String = "<li><a href='#0' data-date='{0}' Class='{1}'>{2}</a></li>"

    '    For Each d As DateTime In dates
    '        If d = Date.Today Then
    '            oTimeLine.InnerHtml += String.Format(ListItemTemplate, d.ToString("dd/MM/yyyy"), "selected", d.ToString("dd MMM"))
    '        ElseIf d > Date.Today Then
    '            oTimeLine.InnerHtml += String.Format(ListItemTemplate, d.ToString("dd/MM/yyyy"), "disabled", d.ToString("dd MMM"))
    '        Else
    '            oTimeLine.InnerHtml += String.Format(ListItemTemplate, d.ToString("dd/MM/yyyy"), String.Empty, d.ToString("dd MMM"))
    '        End If
    '    Next
    'End Sub

    Private Sub InitGoalTimeLine()
        Dim startDate As DateTime = DateTime.Today.AddDays(-20)
        Dim endDate As DateTime = DateTime.Today.AddDays(7)

        Dim dates As IEnumerable(Of DateTime) = Enumerable.Range(0, 1 + CInt((endDate - startDate).TotalDays)).Select(Function(n) startDate.AddDays(n)).ToArray()
        Const oTimeLineListItemTemplate As String = "<li><a href='#0' data-date='{0}' Class='{1}'>{2}</a></li>"
        Const oScrollContentListItemTemplate As String = "<li Class='{0}' data-date='{1}'><div><h2>{2}</h2><em>{3}</em><p>{4}</p></div></li>"


        For Each d As DateTime In dates
            Dim listClass As String = String.Empty
            If d = Date.Today Then
                listClass = "selected"
            ElseIf d > Date.Today Then
                listClass = "disabled"
            Else
                listClass = String.Empty
            End If
            oTimeLine.InnerHtml += String.Format(oTimeLineListItemTemplate, d.ToString("dd/MM/yyyy"), listClass, d.ToString("dd MMM"))
            oScrollContent.InnerHtml += String.Format(oScrollContentListItemTemplate, listClass, d.ToString("dd/MM/yyyy"), "Goals", d.ToString("dd MMM"), "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Illum praesentium officia, fugit recusandae ipsa, quia velit nulla adipisci? Consequuntur aspernatur at, eaque hic repellendus sit dicta consequatur quae, ut harum ipsam molestias maxime non nisi reiciendis eligendi! Doloremque quia pariatur harum ea amet quibusdam quisquam, quae, temporibus dolores porro doloribus.")
        Next

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            InitGoalTimeLine()
        End If
    End Sub

End Class