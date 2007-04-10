﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:2.0.50727.42
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization

'
'This source code was auto-generated by Microsoft.VSDesigner, Version 2.0.50727.42.
'
Namespace ArchetypeFinderWebServiceURL
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="ArchetypeFinderBeanSoapBinding", [Namespace]:="http://archetypeServlet")>  _
    Partial Public Class ArchetypeFinderBeanService
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        Private setMyServletPropertiesOperationCompleted As System.Threading.SendOrPostCallback
        
        Private setOwlModelOperationCompleted As System.Threading.SendOrPostCallback
        
        Private setExcludedParametersForSearchModelOperationCompleted As System.Threading.SendOrPostCallback
        
        Private getArchetypeIdsFromPartialIdOperationCompleted As System.Threading.SendOrPostCallback
        
        Private getArchetypeIdsOperationCompleted As System.Threading.SendOrPostCallback
        
        Private getDescriptionForArchetypeOperationCompleted As System.Threading.SendOrPostCallback
        
        Private getArchetypeInADLOperationCompleted As System.Threading.SendOrPostCallback
        
        Private getArchetypeInHTMLOperationCompleted As System.Threading.SendOrPostCallback
        
        Private getArchetypeHTMLURLOperationCompleted As System.Threading.SendOrPostCallback
        
        Private getArchetypeHTMLURL_langOperationCompleted As System.Threading.SendOrPostCallback
        
        Private getArchetypeADLURLOperationCompleted As System.Threading.SendOrPostCallback
        
        Private getArchetypeADLURL_langOperationCompleted As System.Threading.SendOrPostCallback
        
        Private useDefaultCredentialsSetExplicitly As Boolean
        
        '''<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = Global.ArchetypeEditor.My.MySettings.Default.ArchetypeEditor_ArchetypeFinderWebServiceURL_ArchetypeFinderBeanService
            If (Me.IsLocalFileSystemWebService(Me.Url) = true) Then
                Me.UseDefaultCredentials = true
                Me.useDefaultCredentialsSetExplicitly = false
            Else
                Me.useDefaultCredentialsSetExplicitly = true
            End If
        End Sub
        
        Public Shadows Property Url() As String
            Get
                Return MyBase.Url
            End Get
            Set
                If (((Me.IsLocalFileSystemWebService(MyBase.Url) = true)  _
                            AndAlso (Me.useDefaultCredentialsSetExplicitly = false))  _
                            AndAlso (Me.IsLocalFileSystemWebService(value) = false)) Then
                    MyBase.UseDefaultCredentials = false
                End If
                MyBase.Url = value
            End Set
        End Property
        
        Public Shadows Property UseDefaultCredentials() As Boolean
            Get
                Return MyBase.UseDefaultCredentials
            End Get
            Set
                MyBase.UseDefaultCredentials = value
                Me.useDefaultCredentialsSetExplicitly = true
            End Set
        End Property
        
        '''<remarks/>
        Public Event setMyServletPropertiesCompleted As setMyServletPropertiesCompletedEventHandler
        
        '''<remarks/>
        Public Event setOwlModelCompleted As setOwlModelCompletedEventHandler
        
        '''<remarks/>
        Public Event setExcludedParametersForSearchModelCompleted As setExcludedParametersForSearchModelCompletedEventHandler
        
        '''<remarks/>
        Public Event getArchetypeIdsFromPartialIdCompleted As getArchetypeIdsFromPartialIdCompletedEventHandler
        
        '''<remarks/>
        Public Event getArchetypeIdsCompleted As getArchetypeIdsCompletedEventHandler
        
        '''<remarks/>
        Public Event getDescriptionForArchetypeCompleted As getDescriptionForArchetypeCompletedEventHandler
        
        '''<remarks/>
        Public Event getArchetypeInADLCompleted As getArchetypeInADLCompletedEventHandler
        
        '''<remarks/>
        Public Event getArchetypeInHTMLCompleted As getArchetypeInHTMLCompletedEventHandler
        
        '''<remarks/>
        Public Event getArchetypeHTMLURLCompleted As getArchetypeHTMLURLCompletedEventHandler
        
        '''<remarks/>
        Public Event getArchetypeHTMLURL_langCompleted As getArchetypeHTMLURL_langCompletedEventHandler
        
        '''<remarks/>
        Public Event getArchetypeADLURLCompleted As getArchetypeADLURLCompletedEventHandler
        
        '''<remarks/>
        Public Event getArchetypeADLURL_langCompleted As getArchetypeADLURL_langCompletedEventHandler
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapRpcMethodAttribute("", RequestNamespace:="http://archetypeServlet", ResponseNamespace:="http://archetypeServlet")>  _
        Public Sub setMyServletProperties(ByVal myServletProperties As Object)
            Me.Invoke("setMyServletProperties", New Object() {myServletProperties})
        End Sub
        
        '''<remarks/>
        Public Overloads Sub setMyServletPropertiesAsync(ByVal myServletProperties As Object)
            Me.setMyServletPropertiesAsync(myServletProperties, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub setMyServletPropertiesAsync(ByVal myServletProperties As Object, ByVal userState As Object)
            If (Me.setMyServletPropertiesOperationCompleted Is Nothing) Then
                Me.setMyServletPropertiesOperationCompleted = AddressOf Me.OnsetMyServletPropertiesOperationCompleted
            End If
            Me.InvokeAsync("setMyServletProperties", New Object() {myServletProperties}, Me.setMyServletPropertiesOperationCompleted, userState)
        End Sub
        
        Private Sub OnsetMyServletPropertiesOperationCompleted(ByVal arg As Object)
            If (Not (Me.setMyServletPropertiesCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent setMyServletPropertiesCompleted(Me, New System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapRpcMethodAttribute("", RequestNamespace:="http://archetypeServlet", ResponseNamespace:="http://archetypeServlet")>  _
        Public Sub setOwlModel(ByVal owlModel As Object)
            Me.Invoke("setOwlModel", New Object() {owlModel})
        End Sub
        
        '''<remarks/>
        Public Overloads Sub setOwlModelAsync(ByVal owlModel As Object)
            Me.setOwlModelAsync(owlModel, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub setOwlModelAsync(ByVal owlModel As Object, ByVal userState As Object)
            If (Me.setOwlModelOperationCompleted Is Nothing) Then
                Me.setOwlModelOperationCompleted = AddressOf Me.OnsetOwlModelOperationCompleted
            End If
            Me.InvokeAsync("setOwlModel", New Object() {owlModel}, Me.setOwlModelOperationCompleted, userState)
        End Sub
        
        Private Sub OnsetOwlModelOperationCompleted(ByVal arg As Object)
            If (Not (Me.setOwlModelCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent setOwlModelCompleted(Me, New System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapRpcMethodAttribute("", RequestNamespace:="http://archetypeServlet", ResponseNamespace:="http://archetypeServlet")>  _
        Public Sub setExcludedParametersForSearchModel(ByVal excludedParametersForSearch() As Object)
            Me.Invoke("setExcludedParametersForSearchModel", New Object() {excludedParametersForSearch})
        End Sub
        
        '''<remarks/>
        Public Overloads Sub setExcludedParametersForSearchModelAsync(ByVal excludedParametersForSearch() As Object)
            Me.setExcludedParametersForSearchModelAsync(excludedParametersForSearch, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub setExcludedParametersForSearchModelAsync(ByVal excludedParametersForSearch() As Object, ByVal userState As Object)
            If (Me.setExcludedParametersForSearchModelOperationCompleted Is Nothing) Then
                Me.setExcludedParametersForSearchModelOperationCompleted = AddressOf Me.OnsetExcludedParametersForSearchModelOperationCompleted
            End If
            Me.InvokeAsync("setExcludedParametersForSearchModel", New Object() {excludedParametersForSearch}, Me.setExcludedParametersForSearchModelOperationCompleted, userState)
        End Sub
        
        Private Sub OnsetExcludedParametersForSearchModelOperationCompleted(ByVal arg As Object)
            If (Not (Me.setExcludedParametersForSearchModelCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent setExcludedParametersForSearchModelCompleted(Me, New System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapRpcMethodAttribute("", RequestNamespace:="http://archetypeServlet", ResponseNamespace:="http://archetypeServlet")>  _
        Public Function getArchetypeIdsFromPartialId(ByVal archetypeIdPart As String) As <System.Xml.Serialization.SoapElementAttribute("getArchetypeIdsFromPartialIdReturn")> String()
            Dim results() As Object = Me.Invoke("getArchetypeIdsFromPartialId", New Object() {archetypeIdPart})
            Return CType(results(0),String())
        End Function
        
        '''<remarks/>
        Public Overloads Sub getArchetypeIdsFromPartialIdAsync(ByVal archetypeIdPart As String)
            Me.getArchetypeIdsFromPartialIdAsync(archetypeIdPart, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub getArchetypeIdsFromPartialIdAsync(ByVal archetypeIdPart As String, ByVal userState As Object)
            If (Me.getArchetypeIdsFromPartialIdOperationCompleted Is Nothing) Then
                Me.getArchetypeIdsFromPartialIdOperationCompleted = AddressOf Me.OngetArchetypeIdsFromPartialIdOperationCompleted
            End If
            Me.InvokeAsync("getArchetypeIdsFromPartialId", New Object() {archetypeIdPart}, Me.getArchetypeIdsFromPartialIdOperationCompleted, userState)
        End Sub
        
        Private Sub OngetArchetypeIdsFromPartialIdOperationCompleted(ByVal arg As Object)
            If (Not (Me.getArchetypeIdsFromPartialIdCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent getArchetypeIdsFromPartialIdCompleted(Me, New getArchetypeIdsFromPartialIdCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapRpcMethodAttribute("", RequestNamespace:="http://archetypeServlet", ResponseNamespace:="http://archetypeServlet")>  _
        Public Function getArchetypeIds(ByVal searchParams() As String) As <System.Xml.Serialization.SoapElementAttribute("getArchetypeIdsReturn")> String()
            Dim results() As Object = Me.Invoke("getArchetypeIds", New Object() {searchParams})
            Return CType(results(0),String())
        End Function
        
        '''<remarks/>
        Public Overloads Sub getArchetypeIdsAsync(ByVal searchParams() As String)
            Me.getArchetypeIdsAsync(searchParams, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub getArchetypeIdsAsync(ByVal searchParams() As String, ByVal userState As Object)
            If (Me.getArchetypeIdsOperationCompleted Is Nothing) Then
                Me.getArchetypeIdsOperationCompleted = AddressOf Me.OngetArchetypeIdsOperationCompleted
            End If
            Me.InvokeAsync("getArchetypeIds", New Object() {searchParams}, Me.getArchetypeIdsOperationCompleted, userState)
        End Sub
        
        Private Sub OngetArchetypeIdsOperationCompleted(ByVal arg As Object)
            If (Not (Me.getArchetypeIdsCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent getArchetypeIdsCompleted(Me, New getArchetypeIdsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapRpcMethodAttribute("", RequestNamespace:="http://archetypeServlet", ResponseNamespace:="http://archetypeServlet")>  _
        Public Function getDescriptionForArchetype(ByVal archetypeId As String, ByVal language As String, ByVal descriptionTerms() As String) As <System.Xml.Serialization.SoapElementAttribute("getDescriptionForArchetypeReturn")> String()
            Dim results() As Object = Me.Invoke("getDescriptionForArchetype", New Object() {archetypeId, language, descriptionTerms})
            Return CType(results(0),String())
        End Function
        
        '''<remarks/>
        Public Overloads Sub getDescriptionForArchetypeAsync(ByVal archetypeId As String, ByVal language As String, ByVal descriptionTerms() As String)
            Me.getDescriptionForArchetypeAsync(archetypeId, language, descriptionTerms, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub getDescriptionForArchetypeAsync(ByVal archetypeId As String, ByVal language As String, ByVal descriptionTerms() As String, ByVal userState As Object)
            If (Me.getDescriptionForArchetypeOperationCompleted Is Nothing) Then
                Me.getDescriptionForArchetypeOperationCompleted = AddressOf Me.OngetDescriptionForArchetypeOperationCompleted
            End If
            Me.InvokeAsync("getDescriptionForArchetype", New Object() {archetypeId, language, descriptionTerms}, Me.getDescriptionForArchetypeOperationCompleted, userState)
        End Sub
        
        Private Sub OngetDescriptionForArchetypeOperationCompleted(ByVal arg As Object)
            If (Not (Me.getDescriptionForArchetypeCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent getDescriptionForArchetypeCompleted(Me, New getDescriptionForArchetypeCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapRpcMethodAttribute("", RequestNamespace:="http://archetypeServlet", ResponseNamespace:="http://archetypeServlet")>  _
        Public Function getArchetypeInADL(ByVal archetypeId As String) As <System.Xml.Serialization.SoapElementAttribute("getArchetypeInADLReturn")> String
            Dim results() As Object = Me.Invoke("getArchetypeInADL", New Object() {archetypeId})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub getArchetypeInADLAsync(ByVal archetypeId As String)
            Me.getArchetypeInADLAsync(archetypeId, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub getArchetypeInADLAsync(ByVal archetypeId As String, ByVal userState As Object)
            If (Me.getArchetypeInADLOperationCompleted Is Nothing) Then
                Me.getArchetypeInADLOperationCompleted = AddressOf Me.OngetArchetypeInADLOperationCompleted
            End If
            Me.InvokeAsync("getArchetypeInADL", New Object() {archetypeId}, Me.getArchetypeInADLOperationCompleted, userState)
        End Sub
        
        Private Sub OngetArchetypeInADLOperationCompleted(ByVal arg As Object)
            If (Not (Me.getArchetypeInADLCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent getArchetypeInADLCompleted(Me, New getArchetypeInADLCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapRpcMethodAttribute("", RequestNamespace:="http://archetypeServlet", ResponseNamespace:="http://archetypeServlet")>  _
        Public Function getArchetypeInHTML(ByVal archetypeId As String) As <System.Xml.Serialization.SoapElementAttribute("getArchetypeInHTMLReturn")> String
            Dim results() As Object = Me.Invoke("getArchetypeInHTML", New Object() {archetypeId})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub getArchetypeInHTMLAsync(ByVal archetypeId As String)
            Me.getArchetypeInHTMLAsync(archetypeId, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub getArchetypeInHTMLAsync(ByVal archetypeId As String, ByVal userState As Object)
            If (Me.getArchetypeInHTMLOperationCompleted Is Nothing) Then
                Me.getArchetypeInHTMLOperationCompleted = AddressOf Me.OngetArchetypeInHTMLOperationCompleted
            End If
            Me.InvokeAsync("getArchetypeInHTML", New Object() {archetypeId}, Me.getArchetypeInHTMLOperationCompleted, userState)
        End Sub
        
        Private Sub OngetArchetypeInHTMLOperationCompleted(ByVal arg As Object)
            If (Not (Me.getArchetypeInHTMLCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent getArchetypeInHTMLCompleted(Me, New getArchetypeInHTMLCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapRpcMethodAttribute("", RequestNamespace:="http://archetypeServlet", ResponseNamespace:="http://archetypeServlet")>  _
        Public Function getArchetypeHTMLURL(ByVal archetypeId As String) As <System.Xml.Serialization.SoapElementAttribute("getArchetypeHTMLURLReturn")> String
            Dim results() As Object = Me.Invoke("getArchetypeHTMLURL", New Object() {archetypeId})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub getArchetypeHTMLURLAsync(ByVal archetypeId As String)
            Me.getArchetypeHTMLURLAsync(archetypeId, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub getArchetypeHTMLURLAsync(ByVal archetypeId As String, ByVal userState As Object)
            If (Me.getArchetypeHTMLURLOperationCompleted Is Nothing) Then
                Me.getArchetypeHTMLURLOperationCompleted = AddressOf Me.OngetArchetypeHTMLURLOperationCompleted
            End If
            Me.InvokeAsync("getArchetypeHTMLURL", New Object() {archetypeId}, Me.getArchetypeHTMLURLOperationCompleted, userState)
        End Sub
        
        Private Sub OngetArchetypeHTMLURLOperationCompleted(ByVal arg As Object)
            If (Not (Me.getArchetypeHTMLURLCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent getArchetypeHTMLURLCompleted(Me, New getArchetypeHTMLURLCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapRpcMethodAttribute("", RequestNamespace:="http://archetypeServlet", ResponseNamespace:="http://archetypeServlet")>  _
        Public Function getArchetypeHTMLURL_lang(ByVal archetypeId As String, ByVal language As String) As <System.Xml.Serialization.SoapElementAttribute("getArchetypeHTMLURL_langReturn")> String
            Dim results() As Object = Me.Invoke("getArchetypeHTMLURL_lang", New Object() {archetypeId, language})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub getArchetypeHTMLURL_langAsync(ByVal archetypeId As String, ByVal language As String)
            Me.getArchetypeHTMLURL_langAsync(archetypeId, language, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub getArchetypeHTMLURL_langAsync(ByVal archetypeId As String, ByVal language As String, ByVal userState As Object)
            If (Me.getArchetypeHTMLURL_langOperationCompleted Is Nothing) Then
                Me.getArchetypeHTMLURL_langOperationCompleted = AddressOf Me.OngetArchetypeHTMLURL_langOperationCompleted
            End If
            Me.InvokeAsync("getArchetypeHTMLURL_lang", New Object() {archetypeId, language}, Me.getArchetypeHTMLURL_langOperationCompleted, userState)
        End Sub
        
        Private Sub OngetArchetypeHTMLURL_langOperationCompleted(ByVal arg As Object)
            If (Not (Me.getArchetypeHTMLURL_langCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent getArchetypeHTMLURL_langCompleted(Me, New getArchetypeHTMLURL_langCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapRpcMethodAttribute("", RequestNamespace:="http://archetypeServlet", ResponseNamespace:="http://archetypeServlet")>  _
        Public Function getArchetypeADLURL(ByVal archetypeId As String) As <System.Xml.Serialization.SoapElementAttribute("getArchetypeADLURLReturn")> String
            Dim results() As Object = Me.Invoke("getArchetypeADLURL", New Object() {archetypeId})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub getArchetypeADLURLAsync(ByVal archetypeId As String)
            Me.getArchetypeADLURLAsync(archetypeId, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub getArchetypeADLURLAsync(ByVal archetypeId As String, ByVal userState As Object)
            If (Me.getArchetypeADLURLOperationCompleted Is Nothing) Then
                Me.getArchetypeADLURLOperationCompleted = AddressOf Me.OngetArchetypeADLURLOperationCompleted
            End If
            Me.InvokeAsync("getArchetypeADLURL", New Object() {archetypeId}, Me.getArchetypeADLURLOperationCompleted, userState)
        End Sub
        
        Private Sub OngetArchetypeADLURLOperationCompleted(ByVal arg As Object)
            If (Not (Me.getArchetypeADLURLCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent getArchetypeADLURLCompleted(Me, New getArchetypeADLURLCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapRpcMethodAttribute("", RequestNamespace:="http://archetypeServlet", ResponseNamespace:="http://archetypeServlet")>  _
        Public Function getArchetypeADLURL_lang(ByVal archetypeId As String, ByVal language As String) As <System.Xml.Serialization.SoapElementAttribute("getArchetypeADLURL_langReturn")> String
            Dim results() As Object = Me.Invoke("getArchetypeADLURL_lang", New Object() {archetypeId, language})
            Return CType(results(0),String)
        End Function
        
        '''<remarks/>
        Public Overloads Sub getArchetypeADLURL_langAsync(ByVal archetypeId As String, ByVal language As String)
            Me.getArchetypeADLURL_langAsync(archetypeId, language, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub getArchetypeADLURL_langAsync(ByVal archetypeId As String, ByVal language As String, ByVal userState As Object)
            If (Me.getArchetypeADLURL_langOperationCompleted Is Nothing) Then
                Me.getArchetypeADLURL_langOperationCompleted = AddressOf Me.OngetArchetypeADLURL_langOperationCompleted
            End If
            Me.InvokeAsync("getArchetypeADLURL_lang", New Object() {archetypeId, language}, Me.getArchetypeADLURL_langOperationCompleted, userState)
        End Sub
        
        Private Sub OngetArchetypeADLURL_langOperationCompleted(ByVal arg As Object)
            If (Not (Me.getArchetypeADLURL_langCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent getArchetypeADLURL_langCompleted(Me, New getArchetypeADLURL_langCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        Public Shadows Sub CancelAsync(ByVal userState As Object)
            MyBase.CancelAsync(userState)
        End Sub
        
        Private Function IsLocalFileSystemWebService(ByVal url As String) As Boolean
            If ((url Is Nothing)  _
                        OrElse (url Is String.Empty)) Then
                Return false
            End If
            Dim wsUri As System.Uri = New System.Uri(url)
            If ((wsUri.Port >= 1024)  _
                        AndAlso (String.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) = 0)) Then
                Return true
            End If
            Return false
        End Function
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")>  _
    Public Delegate Sub setMyServletPropertiesCompletedEventHandler(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")>  _
    Public Delegate Sub setOwlModelCompletedEventHandler(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")>  _
    Public Delegate Sub setExcludedParametersForSearchModelCompletedEventHandler(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")>  _
    Public Delegate Sub getArchetypeIdsFromPartialIdCompletedEventHandler(ByVal sender As Object, ByVal e As getArchetypeIdsFromPartialIdCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class getArchetypeIdsFromPartialIdCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String()
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String())
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")>  _
    Public Delegate Sub getArchetypeIdsCompletedEventHandler(ByVal sender As Object, ByVal e As getArchetypeIdsCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class getArchetypeIdsCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String()
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String())
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")>  _
    Public Delegate Sub getDescriptionForArchetypeCompletedEventHandler(ByVal sender As Object, ByVal e As getDescriptionForArchetypeCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class getDescriptionForArchetypeCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String()
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String())
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")>  _
    Public Delegate Sub getArchetypeInADLCompletedEventHandler(ByVal sender As Object, ByVal e As getArchetypeInADLCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class getArchetypeInADLCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")>  _
    Public Delegate Sub getArchetypeInHTMLCompletedEventHandler(ByVal sender As Object, ByVal e As getArchetypeInHTMLCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class getArchetypeInHTMLCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")>  _
    Public Delegate Sub getArchetypeHTMLURLCompletedEventHandler(ByVal sender As Object, ByVal e As getArchetypeHTMLURLCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class getArchetypeHTMLURLCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")>  _
    Public Delegate Sub getArchetypeHTMLURL_langCompletedEventHandler(ByVal sender As Object, ByVal e As getArchetypeHTMLURL_langCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class getArchetypeHTMLURL_langCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")>  _
    Public Delegate Sub getArchetypeADLURLCompletedEventHandler(ByVal sender As Object, ByVal e As getArchetypeADLURLCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class getArchetypeADLURLCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")>  _
    Public Delegate Sub getArchetypeADLURL_langCompletedEventHandler(ByVal sender As Object, ByVal e As getArchetypeADLURL_langCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class getArchetypeADLURL_langCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As String
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),String)
            End Get
        End Property
    End Class
End Namespace