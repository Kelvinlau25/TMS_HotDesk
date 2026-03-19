Imports Microsoft.VisualBasic
Imports System.Net
Imports System.Web.Script.Serialization


Public Class WeatherInfo
    Private CITY_ As City
    Public Property city() As City
        Get
            Return CITY_
        End Get
        Set(ByVal value As City)
            CITY_ = value
        End Set
    End Property
    Private list_ As List(Of List)
    Public Property list() As List(Of List)
        Get
            Return list_
        End Get
        Set(ByVal value As List(Of List))

        End Set
    End Property
End Class

Public Class City
    Private name_ As String
    Public Property name() As String
        Get
            Return name_
        End Get
        Set(ByVal value As String)
            name_ = value
        End Set
    End Property
    Private country_ As String
    Public Property country() As String
        Get
            Return country_
        End Get
        Set(ByVal value As String)
            country_ = value
        End Set
    End Property
End Class

Public Class Temp
    Private day_ As Double
    Public Property day() As Double
        Get
            Return day_
        End Get
        Set(ByVal value As Double)
            day_ = value
        End Set
    End Property
    Private min_ As Double
    Public Property min() As Double
        Get
            Return min_
        End Get
        Set(ByVal value As Double)
            min_ = value
        End Set
    End Property
    Private max_ As Double
    Public Property max() As Double
        Get
            Return max_
        End Get
        Set(ByVal value As Double)
            max_ = value
        End Set
    End Property
    Private night_ As Double
    Public Property night() As Double
        Get
            Return night_
        End Get
        Set(ByVal value As Double)
            night_ = value
        End Set
    End Property
End Class

Public Class Weather
    Private weather_ As String
    Public Property description() As String
        Get
            Return weather_
        End Get
        Set(ByVal value As String)
            weather_ = value
        End Set
    End Property
    Private icon_ As String
    Public Property icon() As String
        Get
            Return icon_
        End Get
        Set(ByVal value As String)
            icon_ = value
        End Set
    End Property
End Class

Public Class List
    Private temp_ As Temp
    Public Property temp() As Temp
        Get
            Return temp_
        End Get
        Set(ByVal value As Temp)
            temp_ = value
        End Set
    End Property
    Private humidity_ As Integer
    Public Property humidity() As Integer
        Get
            Return humidity_
        End Get
        Set(ByVal value As Integer)
            humidity_ = value
        End Set
    End Property
    Private weather_ As List(Of Weather)
    Public Property weather() As List(Of Weather)
        Get
            Return weather_
        End Get
        Set(ByVal value As List(Of Weather))
            weather_ = value
        End Set
    End Property
End Class
