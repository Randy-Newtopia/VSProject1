Imports Newtonsoft.Json

Imports System.Net
Imports System.IO
Imports System.Reflection

Public Class BodyTraceDashboard
    Inherits System.Web.UI.Page

#Region "Json Object 2 Levels"

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

    Public Class ScaleDataFlat
        Public Property deviceId As Long
        Public Property imei As String
        Public Property ts As Long
        Public Property batteryVoltage As Integer
        Public Property signalStrength As Integer
        Public Property values As WeightValues
        Public Property rssi As Integer

        'Public Property tare As Integer
        Public Property weight As Integer
        Public Property unit As Integer
    End Class

#End Region




    Public Class BodyTraceFeed


        Public Function GetBodyTrace_ScaleDataFeeds(ByVal BodyTracePayload As String) As List(Of ScaleData)
            Dim ScaleDataFeed As List(Of ScaleData) = New List(Of ScaleData)

            Try
                Dim x = JsonConvert.DeserializeObject(Of List(Of ScaleData))(BodyTracePayload) ' Deserialize array of Post objects
                ScaleDataFeed = x

            Catch ex As Exception
                Dim m As String = ex.Message
                ScaleDataFeed = Nothing
            End Try

            Return ScaleDataFeed
        End Function

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
        Dim ScaleDataFeed As List(Of ScaleData) = BF.GetBodyTrace_ScaleDataFeeds(txtResponse.Text)

        'Flatten from 2 Level to 1 Level
        Dim ScaleDataFeedFlat As List(Of ScaleDataFlat) = New List(Of ScaleDataFlat)
        For Each f As ScaleData In ScaleDataFeed
            Dim s As ScaleDataFlat = New ScaleDataFlat()
            s.deviceId = f.deviceId
            s.batteryVoltage = f.batteryVoltage
            s.imei = f.imei
            s.rssi = f.rssi
            s.signalStrength = f.signalStrength
            s.ts = f.ts

            If f.values IsNot Nothing Then
                's.tare = f.values.tare
                s.unit = f.values.unit
                s.weight = f.values.weight
            Else
                's.tare = 0
                s.unit = 0
                s.weight = 0
            End If
            ScaleDataFeedFlat.Add(s)
        Next

        gvFeed.DataSource = ScaleDataFeedFlat
        gvFeed.DataBind()

    End Sub


    Public Shared Function ConvertToDataTable(Of T)(ByVal list As IList(Of T)) As DataTable
        Dim table As New DataTable()
        Dim fields() As FieldInfo = GetType(T).GetFields()
        For Each field As FieldInfo In fields
            table.Columns.Add(field.Name, field.FieldType)
        Next
        For Each item As T In list
            Dim row As DataRow = table.NewRow()
            For Each field As FieldInfo In fields
                row(field.Name) = field.GetValue(item)
            Next
            table.Rows.Add(row)
        Next
        Return table
    End Function

End Class