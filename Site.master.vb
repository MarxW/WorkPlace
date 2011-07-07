
Partial Class Site
    Inherits System.Web.UI.MasterPage

    Public Shared Function ReferenceScript(ByVal scriptFile As String) As String
        Dim filePath As String = VirtualPathUtility.ToAbsolute("~/Scripts/" + scriptFile)
        ReferenceScript = "<script type=""text/javascript"" src=""" & filePath & """></script>"
    End Function

End Class

