'
'
'	component:   "openEHR Archetype Project"
'	description: "$DESCRIPTION"
'	keywords:    "Archetype, Clinical, Editor"
'	author:      "Sam Heard"
'	support:     https://openehr.atlassian.net/browse/AEPR
'	copyright:   "Copyright (c) 2004,2005,2006 Ocean Informatics Pty Ltd"
'	license:     "See notice at bottom of class"
'
'

Option Strict On
Imports EiffelKernel = EiffelSoftware.Library.Base.kernel
Imports XMLParser

Namespace ArchetypeEditor.ADL_Classes

    Class ADL_Term
        Inherits RmTerm
        Private EIF_a_Term As openehr.openehr.am.archetype.ontology.ARCHETYPE_TERM

        Public ReadOnly Property EIF_Term() As openehr.openehr.am.archetype.ontology.ARCHETYPE_TERM
            Get
                SetItem("text", sText)
                SetItem("description", sDescription)

                If Not (sComment Is Nothing OrElse sComment = "") Then
                    SetItem("comment", sComment)
                End If

                For Each k As String In OtherAnnotations.Keys
                    SetItem(k, CStr(sAnnotations.Item(k)))
                Next

                Return EIF_a_Term
            End Get
        End Property

        Private Function GetItem(ByVal key As String) As String
            Dim s As EiffelKernel.string.STRING_8 = Eiffel.String(key)

            If EIF_a_Term.has_key(s) Then
                Return EIF_a_Term.item(s).to_cil
            Else
                Return ""
            End If
        End Function

        Private Sub SetItem(ByVal Item As String, ByVal Value As String)
            If EIF_a_Term.has_key(Eiffel.String(Item)) Then
                EIF_a_Term.replace_item(Eiffel.String(Item), Eiffel.String(Value))
            Else
                EIF_a_Term.add_item(Eiffel.String(Item), Eiffel.String(Value))
            End If
        End Sub

        Sub New(ByVal ID As String)
            MyBase.new(ID)
            EIF_a_Term = openehr.openehr.am.archetype.ontology.Create.ARCHETYPE_TERM.make(Eiffel.String(ID))
        End Sub

        Sub New(ByVal EIF_ID As EiffelKernel.string.STRING_8)
            MyBase.New(EIF_ID.to_cil)
            EIF_a_Term = openehr.openehr.am.archetype.ontology.Create.ARCHETYPE_TERM.make(EIF_ID)
        End Sub

        Sub New(ByVal a_Term As RmTerm)
            MyBase.New(a_Term.Code)
            sText = a_Term.Text
            sDescription = a_Term.Description
            sComment = a_Term.Comment
            sAnnotations = a_Term.OtherAnnotations
            EIF_a_Term = openehr.openehr.am.archetype.ontology.Create.ARCHETYPE_TERM.make(Eiffel.String(a_Term.Code))
        End Sub

        Sub New(ByVal code As String, ByVal text As String, ByVal description As String)
            MyBase.New(code)
            sText = text
            sDescription = description
            sComment = ""
            EIF_a_Term = openehr.openehr.am.archetype.ontology.Create.ARCHETYPE_TERM.make(Eiffel.String(code))
        End Sub

        Sub New(ByVal an_adlTerm As openehr.openehr.am.archetype.ontology.ARCHETYPE_TERM)
            MyBase.New(an_adlTerm.code.to_cil)
            EIF_a_Term = an_adlTerm

            For i As Integer = 1 To an_adlTerm.keys.count
                Dim s As String = CType(an_adlTerm.keys.i_th(i), EiffelKernel.string.STRING_8).to_cil

                Select Case s.ToLowerInvariant()
                    Case "text"
                        sText = GetItem("text")
                    Case "description"
                        sDescription = GetItem("description")
                    Case "comment"
                        sComment = GetItem("comment")
                    Case Else
                        OtherAnnotations.Add(s, GetItem(s))
                End Select
            Next
        End Sub

    End Class
End Namespace
'
'***** BEGIN LICENSE BLOCK *****
'Version: MPL 1.1/GPL 2.0/LGPL 2.1
'
'The contents of this file are subject to the Mozilla Public License Version 
'1.1 (the "License"); you may not use this file except in compliance with 
'the License. You may obtain a copy of the License at 
'http://www.mozilla.org/MPL/
'
'Software distributed under the License is distributed on an "AS IS" basis,
'WITHOUT WARRANTY OF ANY KIND, either express or implied. See the License
'for the specific language governing rights and limitations under the
'License.
'
'The Original Code is ADL_Term.vb.
'
'The Initial Developer of the Original Code is
'Sam Heard, Ocean Informatics (www.oceaninformatics.biz).
'Portions created by the Initial Developer are Copyright (C) 2004
'the Initial Developer. All Rights Reserved.
'
'Contributor(s):
'	Heath Frankel
'
'Alternatively, the contents of this file may be used under the terms of
'either the GNU General Public License Version 2 or later (the "GPL"), or
'the GNU Lesser General Public License Version 2.1 or later (the "LGPL"),
'in which case the provisions of the GPL or the LGPL are applicable instead
'of those above. If you wish to allow use of your version of this file only
'under the terms of either the GPL or the LGPL, and not to allow others to
'use your version of this file under the terms of the MPL, indicate your
'decision by deleting the provisions above and replace them with the notice
'and other provisions required by the GPL or the LGPL. If you do not delete
'the provisions above, a recipient may use your version of this file under
'the terms of any one of the MPL, the GPL or the LGPL.
'
'***** END LICENSE BLOCK *****
'
