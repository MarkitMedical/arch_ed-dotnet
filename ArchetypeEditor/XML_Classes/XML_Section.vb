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

Option Explicit On 
Namespace ArchetypeEditor.XML_Classes
    Class XML_SECTION
        Inherits RmSection

        Private Function GetRunTimeConstraintID(ByVal an_attribute As XMLParser.C_ATTRIBUTE) As String

            Dim CodedText As XMLParser.C_COMPLEX_OBJECT
            Dim constraint_object As XMLParser.C_OBJECT
            Dim s As String = ""

            CodedText = CType(an_attribute.children(0), XMLParser.C_COMPLEX_OBJECT)
            an_attribute = CodedText.attributes(0)
            constraint_object = an_attribute.children(0)

            If TypeOf constraint_object Is XMLParser.CONSTRAINT_REF Then
                s = CType(constraint_object, XMLParser.CONSTRAINT_REF).reference
            ElseIf TypeOf constraint_object Is XMLParser.C_CODE_PHRASE Then
                s = CType(constraint_object, XMLParser.C_CODE_PHRASE).code_list(0)
            End If

            ' strip off the square brackets
            s = s.Substring(1, s.Length - 2)
            If s.StartsWith("local::") Then
                ' when the runtime name is constrained by an 'at' code to be the same as the design name ie NodeId
                s = s.Substring(7)
            End If
            Return s

        End Function

        Private Sub ProcessSection(ByVal section As Object, ByVal obj As XMLParser.C_OBJECT, ByVal fileManager As FileManagerLocal)
            'c_complex object means it is a section, otherwise a slot
            'a_rm_section is passed as object so that definition can be passed at the first level
            Select Case obj.GetType.ToString().ToLower(System.Globalization.CultureInfo.InvariantCulture)
                Case "xmlparser.c_complex_object"
                    Dim o As XMLParser.C_COMPLEX_OBJECT = CType(obj, XMLParser.C_COMPLEX_OBJECT)
                    Dim subSection As New RmSection(o, fileManager)

                    If Not o.attributes Is Nothing Then
                        For Each a As XMLParser.C_ATTRIBUTE In o.attributes
                            Select Case a.rm_attribute_name.ToLower(System.Globalization.CultureInfo.InvariantCulture)
                                Case "name"
                                    subSection.NameConstraint = ArchetypeEditor.XML_Classes.XML_RmElement.ProcessText(CType(a.children(0), XMLParser.C_COMPLEX_OBJECT))
                                Case "items"
                                    For Each cco As XMLParser.C_OBJECT In a.children
                                        ProcessSection(subSection, cco, fileManager)
                                    Next
                            End Select
                        Next
                    End If

                    section.Children.Add(subSection)
                Case "xmlparser.archetype_slot"
                    section.children.add(New RmSlot(CType(obj, XMLParser.ARCHETYPE_SLOT)))

                Case Else
                    Debug.Assert(False, "Type is not catered for")
            End Select
        End Sub

        Sub New(ByRef obj As XMLParser.C_COMPLEX_OBJECT, ByVal filemanager As FileManagerLocal)
            MyBase.New(obj, filemanager)

            If Not obj.attributes Is Nothing Then
                For Each attrib As XMLParser.C_ATTRIBUTE In obj.attributes
                    If attrib.rm_attribute_name.ToLower(System.Globalization.CultureInfo.InvariantCulture) = "items" Then
                        ArchetypeEditor.XML_Classes.XML_Tools.SetCardinality(CType(attrib, XMLParser.C_MULTIPLE_ATTRIBUTE).cardinality, Children)

                        For Each section As XMLParser.C_OBJECT In attrib.children
                            ProcessSection(Me, section, filemanager)
                        Next
                    End If
                Next
            End If
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
'The Original Code is XML_Section.vb.
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
