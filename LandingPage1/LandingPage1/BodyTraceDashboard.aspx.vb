Imports Newtonsoft.Json

Imports System.Net
Imports System.IO
Imports System.Reflection

Public Class BodyTraceDashboard
    Inherits System.Web.UI.Page




#Region "Json Object 2 Levels"

    Public Class WeightValues
        Public Property weight As Integer
        Public Property unit As Integer
    End Class

    Public Class ScaleData

        Public Property imei As String
        Public Property ts As Double
        Public Property batteryVoltage As Integer
        Public Property signalStrength As Integer
        Public Property values As WeightValues
        Public Property rssi As Integer

    End Class

    Public Class ScaleDataFlat

        Public Property imei As String
        Public Property timestamp As DateTime

        Public Property batteryVoltage As Integer
        Public Property signalStrength As Integer

        Public Property weight As Integer
        Public Property unitOfMeasure As String

    End Class

#End Region


    Private Function BodytracePayloadSample() As String
        Return "
                {
                  'targetWeights' : [ {
                    'weight' : 203.8,
                    'targetdatetime' : 1497298966000
                  } ],
                  'status' : 'success',
                  'message' : 'User has 127 records In that Date range',
                  'data' : [ {
                    'value' : 184.70,
                    'units' : 'pounds',
                    'recordedTime' : 1459766160000
                  }, {
                    'value' : 151.90,
                    'units' : 'pounds',
                    'recordedTime' : 1459806540000
                  }, {
                    'value' : 186.50,
                    'units' : 'pounds',
                    'recordedTime' : 1459852200000
                  }, {
                    'value' : 151.00,
                    'units' : 'pounds',
                    'recordedTime' : 1459917420000
                  }, {
                    'value' : 186.10,
                    'units' : 'pounds',
                    'recordedTime' : 1460024580000
                  }, {
                    'value' : 185.80,
                    'units' : 'pounds',
                    'recordedTime' : 1460030760000
                  }, {
                    'value' : 185.40,
                    'units' : 'pounds',
                    'recordedTime' : 1460116980000
                  }, {
                    'value' : 138.70,
                    'units' : 'pounds',
                    'recordedTime' : 1460463900000
                  }, {
                    'value' : 187.40,
                    'units' : 'pounds',
                    'recordedTime' : 1460502660000
                  }, {
                    'value' : 187.00,
                    'units' : 'pounds',
                    'recordedTime' : 1460537760000
                  }, {
                    'value' : 140.90,
                    'units' : 'pounds',
                    'recordedTime' : 1460583540000
                  }, {
                    'value' : 185.60,
                    'units' : 'pounds',
                    'recordedTime' : 1460628900000
                  }, {
                    'value' : 187.40,
                    'units' : 'pounds',
                    'recordedTime' : 1460717040000
                  }, {
                    'value' : 186.70,
                    'units' : 'pounds',
                    'recordedTime' : 1460807940000
                  }, {
                    'value' : 187.80,
                    'units' : 'pounds',
                    'recordedTime' : 1460972940000
                  }, {
                    'value' : 186.70,
                    'units' : 'pounds',
                    'recordedTime' : 1460976060000
                  }, {
                    'value' : 187.00,
                    'units' : 'pounds',
                    'recordedTime' : 1461056400000
                  }, {
                    'value' : 187.40,
                    'units' : 'pounds',
                    'recordedTime' : 1461069300000
                  }, {
                    'value' : 186.30,
                    'units' : 'pounds',
                    'recordedTime' : 1461155520000
                  }, {
                    'value' : 48.70,
                    'units' : 'pounds',
                    'recordedTime' : 1461229200000
                  }, {
                    'value' : 48.10,
                    'units' : 'pounds',
                    'recordedTime' : 1461244800000
                  }, {
                    'value' : 186.50,
                    'units' : 'pounds',
                    'recordedTime' : 1461333120000
                  }, {
                    'value' : 186.70,
                    'units' : 'pounds',
                    'recordedTime' : 1461500400000
                  }, {
                    'value' : 186.10,
                    'units' : 'pounds',
                    'recordedTime' : 1461592500000
                  }, {
                    'value' : 140.70,
                    'units' : 'pounds',
                    'recordedTime' : 1461621060000
                  }, {
                    'value' : 186.70,
                    'units' : 'pounds',
                    'recordedTime' : 1461661200000
                  }, {
                    'value' : 186.50,
                    'units' : 'pounds',
                    'recordedTime' : 1461747600000
                  }, {
                    'value' : 187.00,
                    'units' : 'pounds',
                    'recordedTime' : 1461838860000
                  }, {
                    'value' : 186.30,
                    'units' : 'pounds',
                    'recordedTime' : 1461840180000
                  }, {
                    'value' : 185.60,
                    'units' : 'pounds',
                    'recordedTime' : 1462021980000
                  }, {
                    'value' : 187.20,
                    'units' : 'pounds',
                    'recordedTime' : 1462106820000
                  }, {
                    'value' : 185.60,
                    'units' : 'pounds',
                    'recordedTime' : 1462179600000
                  }, {
                    'value' : 186.50,
                    'units' : 'pounds',
                    'recordedTime' : 1462189740000
                  }, {
                    'value' : 186.70,
                    'units' : 'pounds',
                    'recordedTime' : 1462273380000
                  }, {
                    'value' : 185.80,
                    'units' : 'pounds',
                    'recordedTime' : 1462280100000
                  }, {
                    'value' : 186.70,
                    'units' : 'pounds',
                    'recordedTime' : 1462352400000
                  }, {
                    'value' : 184.70,
                    'units' : 'pounds',
                    'recordedTime' : 1463562000000
                  }, {
                    'value' : 185.20,
                    'units' : 'pounds',
                    'recordedTime' : 1463562000000
                  }, {
                    'value' : 184.30,
                    'units' : 'pounds',
                    'recordedTime' : 1463648400000
                  }, {
                    'value' : 184.10,
                    'units' : 'pounds',
                    'recordedTime' : 1463734800000
                  }, {
                    'value' : 183.20,
                    'units' : 'pounds',
                    'recordedTime' : 1463994000000
                  }, {
                    'value' : 149.30,
                    'units' : 'pounds',
                    'recordedTime' : 1463994000000
                  }, {
                    'value' : 184.70,
                    'units' : 'pounds',
                    'recordedTime' : 1463994000000
                  }, {
                    'value' : 184.10,
                    'units' : 'pounds',
                    'recordedTime' : 1464080400000
                  }, {
                    'value' : 184.30,
                    'units' : 'pounds',
                    'recordedTime' : 1464166800000
                  }, {
                    'value' : 183.40,
                    'units' : 'pounds',
                    'recordedTime' : 1464253200000
                  }, {
                    'value' : 183.90,
                    'units' : 'pounds',
                    'recordedTime' : 1464339600000
                  }, {
                    'value' : 183.00,
                    'units' : 'pounds',
                    'recordedTime' : 1465117200000
                  }, {
                    'value' : 183.60,
                    'units' : 'pounds',
                    'recordedTime' : 1465203600000
                  }, {
                    'value' : 183.40,
                    'units' : 'pounds',
                    'recordedTime' : 1465376400000
                  }, {
                    'value' : 183.40,
                    'units' : 'pounds',
                    'recordedTime' : 1465376400000
                  }, {
                    'value' : 181.90,
                    'units' : 'pounds',
                    'recordedTime' : 1465462800000
                  }, {
                    'value' : 180.80,
                    'units' : 'pounds',
                    'recordedTime' : 1465549200000
                  }, {
                    'value' : 139.80,
                    'units' : 'pounds',
                    'recordedTime' : 1466067600000
                  }, {
                    'value' : 181.90,
                    'units' : 'pounds',
                    'recordedTime' : 1466326800000
                  }, {
                    'value' : 50.30,
                    'units' : 'pounds',
                    'recordedTime' : 1466499600000
                  }, {
                    'value' : 49.60,
                    'units' : 'pounds',
                    'recordedTime' : 1466758800000
                  }, {
                    'value' : 49.60,
                    'units' : 'pounds',
                    'recordedTime' : 1466758800000
                  }, {
                    'value' : 49.60,
                    'units' : 'pounds',
                    'recordedTime' : 1466758800000
                  }, {
                    'value' : 181.20,
                    'units' : 'pounds',
                    'recordedTime' : 1467018000000
                  }, {
                    'value' : 183.20,
                    'units' : 'pounds',
                    'recordedTime' : 1467018000000
                  }, {
                    'value' : 183.40,
                    'units' : 'pounds',
                    'recordedTime' : 1468486800000
                  }, {
                    'value' : 184.30,
                    'units' : 'pounds',
                    'recordedTime' : 1468746000000
                  }, {
                    'value' : 183.60,
                    'units' : 'pounds',
                    'recordedTime' : 1468918800000
                  }, {
                    'value' : 183.20,
                    'units' : 'pounds',
                    'recordedTime' : 1468918800000
                  }, {
                    'value' : 184.50,
                    'units' : 'pounds',
                    'recordedTime' : 1469005200000
                  }, {
                    'value' : 183.00,
                    'units' : 'pounds',
                    'recordedTime' : 1469091600000
                  }, {
                    'value' : 139.30,
                    'units' : 'pounds',
                    'recordedTime' : 1469178000000
                  }, {
                    'value' : 182.80,
                    'units' : 'pounds',
                    'recordedTime' : 1469782800000
                  }, {
                    'value' : 182.80,
                    'units' : 'pounds',
                    'recordedTime' : 1469869200000
                  }, {
                    'value' : 181.40,
                    'units' : 'pounds',
                    'recordedTime' : 1470474000000
                  }, {
                    'value' : 182.10,
                    'units' : 'pounds',
                    'recordedTime' : 1470560400000
                  }, {
                    'value' : 182.30,
                    'units' : 'pounds',
                    'recordedTime' : 1470646800000
                  }, {
                    'value' : 183.90,
                    'units' : 'pounds',
                    'recordedTime' : 1470992400000
                  }, {
                    'value' : 183.40,
                    'units' : 'pounds',
                    'recordedTime' : 1471078800000
                  }, {
                    'value' : 139.80,
                    'units' : 'pounds',
                    'recordedTime' : 1471078800000
                  }, {
                    'value' : 182.50,
                    'units' : 'pounds',
                    'recordedTime' : 1471251600000
                  }, {
                    'value' : 182.10,
                    'units' : 'pounds',
                    'recordedTime' : 1471338000000
                  }, {
                    'value' : 184.10,
                    'units' : 'pounds',
                    'recordedTime' : 1471510800000
                  }, {
                    'value' : 183.00,
                    'units' : 'pounds',
                    'recordedTime' : 1471856400000
                  }, {
                    'value' : 182.80,
                    'units' : 'pounds',
                    'recordedTime' : 1471942800000
                  }, {
                    'value' : 182.80,
                    'units' : 'pounds',
                    'recordedTime' : 1472115600000
                  }, {
                    'value' : 181.90,
                    'units' : 'pounds',
                    'recordedTime' : 1472288400000
                  }, {
                    'value' : 182.10,
                    'units' : 'pounds',
                    'recordedTime' : 1472461200000
                  }, {
                    'value' : 182.10,
                    'units' : 'pounds',
                    'recordedTime' : 1472461200000
                  }, {
                    'value' : 183.60,
                    'units' : 'pounds',
                    'recordedTime' : 1472893200000
                  }, {
                    'value' : 182.80,
                    'units' : 'pounds',
                    'recordedTime' : 1472979600000
                  }, {
                    'value' : 182.30,
                    'units' : 'pounds',
                    'recordedTime' : 1473325200000
                  }, {
                    'value' : 183.00,
                    'units' : 'pounds',
                    'recordedTime' : 1473584400000
                  }, {
                    'value' : 183.90,
                    'units' : 'pounds',
                    'recordedTime' : 1473930000000
                  }, {
                    'value' : 185.00,
                    'units' : 'pounds',
                    'recordedTime' : 1474189200000
                  }, {
                    'value' : 185.60,
                    'units' : 'pounds',
                    'recordedTime' : 1474966800000
                  }, {
                    'value' : 188.30,
                    'units' : 'pounds',
                    'recordedTime' : 1475658000000
                  }, {
                    'value' : 185.80,
                    'units' : 'pounds',
                    'recordedTime' : 1475658000000
                  }, {
                    'value' : 184.50,
                    'units' : 'pounds',
                    'recordedTime' : 1475830800000
                  }, {
                    'value' : 184.50,
                    'units' : 'pounds',
                    'recordedTime' : 1475830800000
                  }, {
                    'value' : 184.50,
                    'units' : 'pounds',
                    'recordedTime' : 1475830800000
                  }, {
                    'value' : 184.30,
                    'units' : 'pounds',
                    'recordedTime' : 1476349200000
                  }, {
                    'value' : 183.90,
                    'units' : 'pounds',
                    'recordedTime' : 1476435600000
                  }, {
                    'value' : 183.40,
                    'units' : 'pounds',
                    'recordedTime' : 1477645200000
                  }, {
                    'value' : 180.30,
                    'units' : 'pounds',
                    'recordedTime' : 1477990800000
                  }, {
                    'value' : 183.20,
                    'units' : 'pounds',
                    'recordedTime' : 1478336400000
                  }, {
                    'value' : 180.60,
                    'units' : 'pounds',
                    'recordedTime' : 1478509200000
                  }, {
                    'value' : 49.60,
                    'units' : 'pounds',
                    'recordedTime' : 1478595600000
                  }, {
                    'value' : 179.50,
                    'units' : 'pounds',
                    'recordedTime' : 1478854800000
                  }, {
                    'value' : 181.20,
                    'units' : 'pounds',
                    'recordedTime' : 1478941200000
                  }, {
                    'value' : 178.40,
                    'units' : 'pounds',
                    'recordedTime' : 1479114000000
                  }, {
                    'value' : 180.60,
                    'units' : 'pounds',
                    'recordedTime' : 1479286800000
                  }, {
                    'value' : 181.70,
                    'units' : 'pounds',
                    'recordedTime' : 1479632400000
                  }, {
                    'value' : 181.70,
                    'units' : 'pounds',
                    'recordedTime' : 1479718800000
                  }, {
                    'value' : 181.40,
                    'units' : 'pounds',
                    'recordedTime' : 1479978000000
                  }, {
                    'value' : 49.60,
                    'units' : 'pounds',
                    'recordedTime' : 1479978000000
                  }, {
                    'value' : 182.80,
                    'units' : 'pounds',
                    'recordedTime' : 1480323600000
                  }, {
                    'value' : 180.60,
                    'units' : 'pounds',
                    'recordedTime' : 1480496400000
                  }, {
                    'value' : 181.00,
                    'units' : 'pounds',
                    'recordedTime' : 1480842000000
                  }, {
                    'value' : 181.90,
                    'units' : 'pounds',
                    'recordedTime' : 1480928400000
                  }, {
                    'value' : 219.00,
                    'units' : 'pounds',
                    'recordedTime' : 1484164920000
                  }, {
                    'value' : 218.50,
                    'units' : 'pounds',
                    'recordedTime' : 1484254320000
                  }, {
                    'value' : 218.00,
                    'units' : 'pounds',
                    'recordedTime' : 1484340780000
                  }, {
                    'value' : 218.00,
                    'units' : 'pounds',
                    'recordedTime' : 1484673780000
                  }, {
                    'value' : 219.30,
                    'units' : 'pounds',
                    'recordedTime' : 1485194580000
                  }, {
                    'value' : 219.00,
                    'units' : 'pounds',
                    'recordedTime' : 1485280980000
                  }, {
                    'value' : 219.10,
                    'units' : 'pounds',
                    'recordedTime' : 1485367440000
                  }, {
                    'value' : 218.90,
                    'units' : 'pounds',
                    'recordedTime' : 1485453840000
                  }, {
                    'value' : 218.50,
                    'units' : 'pounds',
                    'recordedTime' : 1485540240000
                  }, {
                    'value' : 217.50,
                    'units' : 'pounds',
                    'recordedTime' : 1485722100000
                  }, {
                    'value' : 216.00,
                    'units' : 'pounds',
                    'recordedTime' : 1485981360000
                  } ]
                }


        "
    End Function

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

        If ScaleDataFeed IsNot Nothing Then
            'Flatten from 2 Level to 1 Level
            Dim ScaleDataFeedFlat As List(Of ScaleDataFlat) = New List(Of ScaleDataFlat)
            For Each f As ScaleData In ScaleDataFeed
                Dim s As ScaleDataFlat = New ScaleDataFlat()

                s.batteryVoltage = f.batteryVoltage
                s.imei = f.imei
                s.signalStrength = f.signalStrength
                s.timestamp = UnixToDateTime(f.ts)
                s.unitOfMeasure = "pounds"
                s.weight = f.values.weight * 0.00220462
                ScaleDataFeedFlat.Add(s)

            Next
            gvFeed.DataSource = ScaleDataFeedFlat
            gvFeed.DataBind()

        Else
            'Render Error
            gvFeed.DataSource = Nothing
            gvFeed.DataBind()
        End If

    End Sub

    Public Function UnixToDateTime(ByVal strUnixTime As Double) As DateTime

        Dim nTimestamp As Double = strUnixTime
        Dim nDateTime As System.DateTime = New System.DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc)
        nDateTime = nDateTime.AddSeconds(Math.Round(nTimestamp / 1000))

        Return nDateTime

    End Function

End Class