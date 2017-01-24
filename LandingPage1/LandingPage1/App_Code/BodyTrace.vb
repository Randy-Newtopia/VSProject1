Imports Newtonsoft.Json

'Namespace BodyTraceNS

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

    Public Class BodyTrace_PostWrapper
        Public posts() As ScaleData
    End Class


    '{"imei":”012896009462125”,"ts":1380562575798,"batteryVoltage":5522,"signalStrength":91,"values":{"unit":16400,"weight":69800}}	

    '   {
    '  "imei": "013950008564156",
    '  "ts": 1485536188437,
    '  "batteryVoltage": 5294,
    '  "signalStrength": 54,
    '  "values": {
    '    "unit": 1,
    '    "tare": 100,
    '    "weight": 116800
    '  },
    '  "rssi": 87,
    '  "deviceId": 1395000856415
    '},




    Public Class BodyTraceFeed


        'For example To query recent weight values from a scale With IMEI 012345678901237: curl -v -H 'Accept: application/json' --user "operations@company.com:mysecretpassword" "https://us.data.bodytrace.com/1/device/012345678901237/datavalues?names=batteryVoltage, signalStrength,values/weight,values/unit" 
        'To query the last 20 blood pressure monitor readings from a blood pressure monitor with IMEI 012345678901237 curl -v -H 'Accept: application/json' --user "operations@company.com:mysecretpassword" "https://us.data.bodytrace.com/1/device/012345678901237/datavalues?names=batteryVoltage, signalStrength,values/diastolic,values/systolic,values/pulse,values/unit&limit=20" 

        Private Function GetBodyTrace_ScaleDataFeeds(ByVal BodyTracePayload As String) As ScaleData()

            Dim json As String = BodyTracePayload
            Dim postWrapper = JsonConvert.DeserializeObject(Of BodyTrace_PostWrapper)(json) ' Deserialize array of Post objects

            Dim BodyTrace_ScaleDataFeeds As ScaleData() = postWrapper.posts
            Return BodyTrace_ScaleDataFeeds

        End Function

    End Class


    Public Class BodyTrace_Configuration

        Public Property GetCall As String = "https://us.data.bodytrace.com/1/device/013950008564156/datamessages?from=1451606400"
        Public Property GetCallURL As String = "https://us.data.bodytrace.com/1/device/%1/datamessages?from=%2"
        Public Property imei As String = "013950008564156"
        Public Property UserName As String = "smandipalle@newtopia.com"
        Public Property Password As String = "iq28T22ytyq9izfowhfeg"


        'For example To query recent weight values from a scale With IMEI 012345678901237: curl -v -H 'Accept: application/json' --user "operations@company.com:mysecretpassword" "https://us.data.bodytrace.com/1/device/012345678901237/datavalues?names=batteryVoltage, signalStrength,values/weight,values/unit" 
        'To query the last 20 blood pressure monitor readings from a blood pressure monitor with IMEI 012345678901237 curl -v -H 'Accept: application/json' --user "operations@company.com:mysecretpassword" "https://us.data.bodytrace.com/1/device/012345678901237/datavalues?names=batteryVoltage, signalStrength,values/diastolic,values/systolic,values/pulse,values/unit&limit=20" 

    End Class


'End Namespace
