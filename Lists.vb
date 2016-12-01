
Class Lists

    Private _getItemText As String

    Property GetItemText(listBox As ListBox) As String
        Get
            Return _getItemText
        End Get
        Set(value As String)
            _getItemText = value
        End Set
    End Property

End Class
