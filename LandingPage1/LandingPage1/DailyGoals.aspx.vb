'Source credits:: https://codyhouse.co/demo/horizontal-timeline/index.html
Imports System
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Imports System.IO


Namespace Global.NewtopiaDailyGoals

    Public Class Comments
        Public text As String
    End Class

    Public Class Goal
        Public type As Integer
        Public title As String
        Public status As Integer
        Public goal_id As String
        Public comments As Comments
    End Class

    Public Class dailyschedule
        Public schedule As String
        Public status As Integer
        Public goals As List(Of Goal)
    End Class

    Public Class Payload
        Public status As String
        Public dailyschedules As list(Of dailyschedule)
    End Class

End Namespace



Public Class DailyGoals
    Inherits System.Web.UI.Page

    'Test Payload1
    Private Function GetDailyGoals() As String
        Return "
            {
              'status': 'success',
              'dailyschedules': [
                {
                  'schedule': '2017-01-18',
                  'status': 0,
                  'goals': [
                    {
                      'type': 1,
                      'title': 'Eat Breakfast',
                      'status': 0,
                      'goal_id': 'a0sg0000002cJyIAAU',
                      'comments': {
                        'text': 'Take Breakfast Rationale'
                      }
                    }
                  ]
                },
                {
                  'schedule': '2017-01-19',
                  'status': 0,
                  'goals': [
                    {
                      'type': 1,
                      'title': 'Eat Breakfast',
                      'status': 0,
                      'goal_id': 'a0sg0000002cJyIAAU',
                      'comments': {
                        'text': 'Take Breakfast Rationale'
                      }
                    }
                  ]
                },
                {
                  'schedule': '2017-01-20',
                  'status': 0,
                  'goals': [
                    {
                      'type': 1,
                      'title': 'Eat Breakfast',
                      'status': 0,
                      'goal_id': 'a0sg0000002cJyIAAU',
                      'comments': {
                        'text': 'Take Breakfast Rationale'
                      }
                    }
                  ]
                },
                {
                  'schedule': '2017-01-21',
                  'status': 0,
                  'goals': [
                    {
                      'type': 1,
                      'title': 'Eat Breakfast',
                      'status': 0,
                      'goal_id': 'a0sg0000002cJyIAAU',
                      'comments': {
                        'text': 'Take Breakfast Rationale'
                      }
                    }
                  ]
                },
                {
                  'schedule': '2017-01-28',
                  'status': 0,
                  'goals': [
                    {
                      'type': 1,
                      'title': 'Eat Breakfast',
                      'status': 0,
                      'goal_id': 'a0sg0000002cJy3AAE',
                      'comments': {
                        'text': 'Take Breakfast Rationale'
                      }
                    }
                  ]
                },
                {
                  'schedule': '2017-01-29',
                  'status': 0,
                  'goals': [
                    {
                      'type': 1,
                      'title': 'Eat Breakfast',
                      'status': 0,
                      'goal_id': 'a0sg0000002cJy3AAE',
                      'comments': {
                        'text': 'Take Breakfast Rationale'
                      }
                    }
                  ]
                },
                {
                  'schedule': '2017-02-01',
                  'status': 0,
                  'goals': [
                    {
                      'type': 1,
                      'title': 'Eat Breakfast',
                      'status': 0,
                      'goal_id': 'a0sg0000002cJyDAAU',
                      'comments': {
                        'text': 'Take Breakfast Rationale'
                      }
                    }
                  ]
                }
              ]
            }
        "
    End Function

    'Test Payload From File
    Private Function GetDailyGoals(ByVal Filepath As String) As String
        Dim jsonStr As String = File.ReadAllText(Filepath)

        Return jsonStr
    End Function

    Private Sub InitGoalTimeLine(ByVal jsonStr As String)
        Dim startDate As DateTime = DateTime.Today.AddDays(-20)
        Dim endDate As DateTime = DateTime.Today.AddDays(7)

        Try
            Dim x As NewtopiaDailyGoals.Payload = JsonConvert.DeserializeObject(Of NewtopiaDailyGoals.Payload)(GetDailyGoals()) ' Deserialize array of Post objects

            Dim dates As IEnumerable(Of DateTime) = Enumerable.Range(0, 1 + CInt((endDate - startDate).TotalDays)).Select(Function(n) startDate.AddDays(n)).ToArray()

            'Get List Item Template from UI
            Dim oTimeLineListItemTemplate As String = oTimeLine.InnerHtml
            oTimeLine.InnerHtml = String.Empty
            Dim oScrollContentListItemTemplate As String = oScrollContent.InnerHtml
            oScrollContent.InnerHtml = String.Empty

            Dim listClass As String = "selected"
            For Each y As NewtopiaDailyGoals.dailyschedule In x.dailyschedules
                oTimeLine.InnerHtml += String.Format(oTimeLineListItemTemplate, Date.Parse(y.schedule).ToString("dd/MM/yyyy"), listClass, Date.Parse(y.schedule).ToString("dd MMM"))




                oScrollContent.InnerHtml += String.Format(oScrollContentListItemTemplate, listClass, Date.Parse(y.schedule).ToString("dd/MM/yyyy"), "Goals", Date.Parse(y.schedule).ToString("dd MMM"), y.goals(0).title, y.goals(0).status, y.goals(0).comments.text
                                                          )
                If listClass = "selected" Then
                    listClass = ""
                End If
            Next
            'For Each d As DateTime In dates
            '    Dim listClass As String = String.Empty
            '    If d = Date.Today Then
            '        listClass = "selected"
            '    ElseIf d > Date.Today Then
            '        listClass = "disabled"
            '    Else
            '        listClass = String.Empty
            '    End If
            '    oTimeLine.InnerHtml += String.Format(oTimeLineListItemTemplate, d.ToString("dd/MM/yyyy"), listClass, d.ToString("dd MMM"))
            '    oScrollContent.InnerHtml += String.Format(oScrollContentListItemTemplate, listClass, d.ToString("dd/MM/yyyy"), "Goals", d.ToString("dd MMM"), "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Illum praesentium officia, fugit recusandae ipsa, quia velit nulla adipisci? Consequuntur aspernatur at, eaque hic repellendus sit dicta consequatur quae, ut harum ipsam molestias maxime non nisi reiciendis eligendi! Doloremque quia pariatur harum ea amet quibusdam quisquam, quae, temporibus dolores porro doloribus.")
            'Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            'Dim jSonStr As String = GetJSonStr("\JsonObj\Goals_Payload.txt")
            Dim jSonStr As String = GetDailyGoals()
            'Dim json As String = File.ReadAllText("JSON File Path")
            'Dim o As JObject = JObject.Parse(json)

            InitGoalTimeLine(jSonStr)

        End If
    End Sub

End Class