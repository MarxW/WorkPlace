Imports Microsoft.VisualBasic
Imports System.Data.Linq
Imports System.Net.Mail

Namespace Workplace

    Public Class Mailer

        Public Shared Sub sendNewUserEmail(ByVal email As String, ByVal password As String, ByVal firstname As String, ByVal lastname As String)
            Dim appName As String = HttpContext.GetGlobalResourceObject("Global.resx", "applicationName")
            Dim message As String = String.Format(HttpContext.GetGlobalResourceObject("Messages.resx", "newUser"), _
                                                  firstname & " " & lastname, _
                                                  appName, _
                                                  appName, _
                                                  HttpContext.Current.Request.Url.Scheme & _
                                                  System.Uri.SchemeDelimiter & _
                                                  HttpContext.Current.Request.Url.Host, _
                                                  email, _
                                                  password, _
                                                  HttpContext.GetGlobalResourceObject("Global.resx", "roleManager"))
            Dim title As String = String.Format(HttpContext.GetGlobalResourceObject("Messages.resx", "newUserTitle"), appName)
            sendEmail(title, message, email)
        End Sub

        Public Shared Function getDefaultEmail() As String
            Return System.Configuration.ConfigurationManager.AppSettings("masterEmail")
        End Function

        Public Shared Function getDefaultBCCEmail() As String
            Return System.Configuration.ConfigurationManager.AppSettings("bccEmail")
        End Function

        Public Shared Sub sendEmail(ByVal subject As String, ByVal message As String, ByVal recipient As String)
            sendEmail(subject, message, recipient, getDefaultEmail())
        End Sub

        Public Shared Sub sendEmail(ByVal subject As String, ByVal message As String, ByVal recipients As String())
            sendEmail(subject, message, recipients, getDefaultEmail())
        End Sub

        Public Shared Sub sendEmail(ByVal subject As String, ByVal message As String, ByVal recipients As String(), ByVal singleMails As Boolean)
            sendEmail(subject, message, recipients, getDefaultEmail(), singleMails)
        End Sub

        Public Shared Sub sendEmail(ByVal subject As String, ByVal message As String, ByVal recipient As String, ByVal sender As String)
            Dim mail As New MailMessage(sender, recipient)
            mail.Bcc.Add(getDefaultBCCEmail())
            mail.IsBodyHtml = False
            mail.Body = message.Replace("\n", Environment.NewLine).Replace("<br />", Environment.NewLine)
            mail.Subject = subject
            Dim smtp As New SmtpClient
            smtp.Send(mail)
        End Sub

        Public Shared Sub sendEmail(ByVal subject As String, ByVal message As String, ByVal recipients As String(), ByVal sender As String)
            Dim mail As New MailMessage()
            mail.From = New MailAddress(sender)
            For Each s As String In recipients
                mail.To.Add(s)
            Next s
            mail.Bcc.Add(getDefaultBCCEmail())
            mail.IsBodyHtml = False
            mail.Body = message.Replace("\n", Environment.NewLine).Replace("<br />", Environment.NewLine)
            mail.Subject = subject
            Dim smtp As New SmtpClient
            smtp.Send(mail)
        End Sub

        Public Shared Sub sendEmail(ByVal subject As String, ByVal message As String, ByVal recipients As String(), ByVal sender As String, ByVal singleMails As Boolean)
            If singleMails = False Then
                sendEmail(subject, message, recipients, sender)
            Else
                For Each s As String In recipients
                    sendEmail(subject, message, s, sender)
                Next s
            End If
        End Sub

    End Class

End Namespace

