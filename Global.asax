<%@ Application Language="VB" %>

<script runat="server">

    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code, der beim Starten der Anwendung ausgeführt wird.
    End Sub
    
    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code, der beim Herunterfahren der Anwendung ausgeführt wird.
    End Sub
        
    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
        ' Code, der bei einem nicht behandelten Fehler ausgeführt wird.
    End Sub

    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
        ' Code, der beim Starten einer neuen Sitzung ausgeführt wird.
    End Sub

    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
        ' Code, der am Ende einer Sitzung ausgeführt wird. 
        ' Hinweis: Das Session_End-Ereignis wird nur ausgelöst, wenn der sessionstate-Modus
        ' in der Datei "Web.config" auf InProc festgelegt wird. Wenn der Sitzungsmodus auf StateServer festgelegt wird 
        ' oder auf SQLServer, wird das Ereignis nicht ausgelöst.
    End Sub
       
</script>