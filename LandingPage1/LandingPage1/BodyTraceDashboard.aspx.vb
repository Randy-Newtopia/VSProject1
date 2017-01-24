Imports Newtonsoft.Json

Imports System.Net
Imports System.IO

Public Class BodyTraceDashboard
    Inherits System.Web.UI.Page

    Public Class WeightValues
        Public Property unit As Integer
        Public Property tare As Integer
        Public Property weight As Integer
    End Class

    Public Class ScaleData
        Public Property imei As String
        Public Property ts As Long
        Public Property batteryVoltage As Integer
        Public Property signalStrength As Integer
        Public Property values As WeightValues
        Public Property rssi As Integer
        Public Property deviceId As Long
    End Class

    Public Class BodyTraceFeed

        Public Sub GetBodyTrace_ScaleDataFeeds(ByVal BodyTracePayload As String)
            Try
                Dim x = JsonConvert.DeserializeObject(Of List(Of ScaleData))(BodyTracePayload) ' Deserialize array of Post objects
                MsgBox(x.ToList.ToString)

            Catch ex As Exception
                Dim m As String = ex.Message
            End Try

        End Sub

    End Class


    Public Class BodyTrace_Configuration

        Public Property GetCallURL As String = "https://us.data.bodytrace.com/1/device/{%1}/datamessages"

        Public Property imei As String = "013950008564156"
        Public Property UserName As String = "smandipalle@newtopia.com"
        Public Property Password As String = "iq28T22ytyq9izfowhfeg"

    End Class



    Private Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click

        Dim BT As BodyTrace_Configuration = New BodyTrace_Configuration
        Dim EndpointURLByDevice As String = BT.GetCallURL.Replace("{%1}", txtImei.Text)
        txtEndpoint.Text = EndpointURLByDevice

    End Sub

    Private Sub btnGet_Click(sender As Object, e As EventArgs) Handles btnGet.Click

        Try

            Dim BT As BodyTrace_Configuration = New BodyTrace_Configuration
            Dim EndpointURLByDevice As String = BT.GetCallURL.Replace("{%1}", txtImei.Text)

            Dim wc As New System.Net.WebClient

            Dim myReq As WebRequest = WebRequest.Create(EndpointURLByDevice)
            Dim mycache As CredentialCache = New CredentialCache()
            mycache.Add(New Uri(EndpointURLByDevice), "Basic", New NetworkCredential(BT.UserName, BT.Password))
            myReq.Credentials = mycache

            Dim postresponse As HttpWebResponse
            postresponse = DirectCast(myReq.GetResponse, HttpWebResponse)
            Dim postreqreader As New StreamReader(postresponse.GetResponseStream())
            Dim reponseString As String = postreqreader.ReadToEnd

            txtResponse.Text = reponseString

        Catch ex As Exception
            Dim m As String = ex.Message
        End Try

    End Sub

    Private Sub BodyTraceDashboard_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim BT As BodyTrace_Configuration = New BodyTrace_Configuration
            txtImei.Text = BT.imei
        End If
    End Sub

    Private Sub btnDeserialize_Click(sender As Object, e As EventArgs) Handles btnDeserialize.Click

        Dim BF As BodyTraceFeed = New BodyTraceFeed
        BF.GetBodyTrace_ScaleDataFeeds(txtResponse.Text)

    End Sub

End Class