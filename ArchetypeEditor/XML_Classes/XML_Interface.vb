'
'
'	component:   "openEHR Archetype Project"
'	description: "$DESCRIPTION"
'	keywords:    "Archetype, Clinical, Editor"
'	author:      "Sam Heard"
'	support:     http://www.openehr.org/issues/browse/AEPR
'	copyright:   "Copyright (c) 2004,2005,2006 Ocean Informatics Pty Ltd"
'	license:     "See notice at bottom of class"
'
'	file:        "$URL: http://svn.openehr.org/knowledge_tools_dotnet/TRUNK/ArchetypeEditor/XML_Classes/XML_Interface.vb $"
'	revision:    "$LastChangedRevision$"
'	last_change: "$LastChangedDate: 2006-05-17 18:54:30 +0930 (Wed, 17 May 2006) $"
'
'

Option Strict On
Namespace ArchetypeEditor.XML_Classes
    Class XML_Interface
        Implements Parser
        Private mXmlParser As XMLParser.XmlArchetypeParser
        Private mFileName As String
        Private mArchetype As XML_Archetype
        Private mOpenFileError As Boolean
        Private mWriteFileError As Boolean

        Public ReadOnly Property FileName() As String Implements Parser.FileName
            Get
                Return mFileName
            End Get
        End Property
        Public ReadOnly Property Xml_Parser() As XMLParser.XmlArchetypeParser
            Get
                Return mXmlParser
            End Get
        End Property
        Public ReadOnly Property AvailableFormats() As ArrayList Implements Parser.AvailableFormats
            Get
                Return mXmlParser.AvailableFormats
            End Get
        End Property
        Public ReadOnly Property TypeName() As String Implements Parser.TypeName
            Get
                Return "xml"
            End Get
        End Property
        Public ReadOnly Property Status() As String Implements Parser.Status
            Get
                Return mXmlParser.Status
            End Get
        End Property
        Public ReadOnly Property ArchetypeAvailable() As Boolean Implements Parser.ArchetypeAvailable
            Get
                Return mXmlParser.ArchetypeAvailable
            End Get
        End Property
        Public ReadOnly Property Archetype() As Archetype Implements Parser.Archetype
            Get
                Return mArchetype
            End Get
        End Property
        Public ReadOnly Property OpenFileError() As Boolean Implements Parser.OpenFileError
            Get
                Return mOpenFileError
            End Get
        End Property
        Public ReadOnly Property WriteFileError() As Boolean Implements Parser.WriteFileError
            Get
                Return mWriteFileError
            End Get
        End Property

        Public Sub ResetAll() Implements Parser.ResetAll
            mXmlParser.ResetAll()
        End Sub

        Public Sub Serialise(ByVal a_format As String) Implements Parser.Serialise
            If Me.AvailableFormats.Contains(a_format) Then
                Try
                    mArchetype.MakeParseTree()
                Catch e As Exception
                    Debug.Assert(False, e.Message)
                    MessageBox.Show(AE_Constants.Instance.Error_saving, AE_Constants.Instance.MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Sub


        Public Sub OpenFile(ByVal a_file_name As String, ByVal a_filemanager As FileManagerLocal) Implements Parser.OpenFile

            Dim current_culture As System.Globalization.CultureInfo = System.Globalization.CultureInfo.CurrentCulture
            Dim replace_culture As Boolean

            mOpenFileError = True  ' default unless all goes wel
            mFileName = a_file_name

            ' ADDED 2004-11-18
            ' Sam Heard
            ' This code is essential to ensure that the parser reads regardless of the local culture

            If System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator <> "." Then
                replace_culture = True
                System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture()
            End If

            mXmlParser.OpenFile(a_file_name)

            ' check that file openned successfully by checking status
            If Not mXmlParser.OpenFileError Then
                Dim the_ontology As XML_Classes.XML_Ontology
                the_ontology = New XML_Classes.XML_Ontology(mXmlParser)
                a_filemanager.OntologyManager.Ontology = the_ontology
                mArchetype = New XML_Archetype(mXmlParser, a_filemanager)
                If mXmlParser.ArchetypeAvailable Then
                    mOpenFileError = False
                End If
            End If
            If replace_culture Then
                System.Threading.Thread.CurrentThread.CurrentCulture = current_culture
            End If
        End Sub

        Public Sub NewArchetype(ByVal an_ArchetypeID As ArchetypeID, ByVal LanguageCode As String) Implements Parser.NewArchetype
            mArchetype = New XML_Archetype(mXmlParser, an_ArchetypeID, LanguageCode)
        End Sub

        Public Function GetCanonicalArchetype() As XMLParser.ARCHETYPE Implements Parser.GetCanonicalArchetype
            mArchetype.MakeParseTree()
            Dim canonicalArchetype As XMLParser.ARCHETYPE = mXmlParser.GetCanonicalArchetype()

            Return canonicalArchetype
        End Function

        Public Sub WriteFile(ByVal a_file_name As String, ByVal output_format As String, ByVal parserSynchronised As Boolean) Implements Parser.WriteFile
            'Change from intermediate format to XML
            ' then make it again

            Debug.Assert(output_format = "xml")

            mWriteFileError = True ' default is that an error occurred
            Try
                If Not parserSynchronised Then
                    mArchetype.MakeParseTree()
                End If
                If mXmlParser.ArchetypeAvailable Then
                    'mArchetype.RemoveUnusedCodes()
                    mXmlParser.WriteFile(a_file_name)
                    If mXmlParser.WriteFileError Then
                        MessageBox.Show(mXmlParser.Status)
                        mXmlParser.ResetAll()
                    Else
                        mWriteFileError = False
                    End If
                Else
                    MessageBox.Show("Archetype not available - error on making parse tree")
                End If
            Catch ex As Exception
                MessageBox.Show(AE_Constants.Instance.Error_saving & " " & ex.Message, AE_Constants.Instance.MessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Public Sub New()
            mXmlParser = New XMLParser.XmlArchetypeParser
        End Sub

        Public Sub New(ByVal a_parser As XMLParser.XmlArchetypeParser)
            mXmlParser = a_parser
            mFileName = a_parser.FileName
            If a_parser.ArchetypeAvailable Then
                mArchetype = New XML_Archetype(a_parser)
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
'The Original Code is XML_Interface.vb.
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
