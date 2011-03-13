'
'
'	component:   "openEHR Archetype Project"
'	description: "Specialisation of the Ontology class to work with ADL"
'	keywords:    "Archetype, Clinical, Editor"
'	author:      "Sam Heard"
'	support:     http://www.openehr.org/issues/browse/AEPR
'	copyright:   "Copyright (c) 2004,2005,2006 Ocean Informatics Pty Ltd"
'	license:     "See notice at bottom of class"
'
'	file:        "$Source: source/vb.net/archetype_editor/XML_Classes/SCCS/s.XML_Ontology.vb $"
'	revision:    "$LastChangedRevision$"
'	last_change: "$LastChangedDate: 2006-05-17 18:54:30 +0930 (Wed, 17 May 2006) $"
'
'
Option Strict On
Option Explicit On 

Namespace ArchetypeEditor.XML_Classes
    Friend Class XML_Ontology
        Inherits Ontology
        Private archetypeParser As XMLParser.XmlArchetypeParser
        Private sLanguageCode As String

        Public Overrides ReadOnly Property PrimaryLanguageCode() As String
            Get
                Return archetypeParser.Archetype.original_language.code_string
            End Get
        End Property
        Public Overrides ReadOnly Property LanguageCode() As String
            Get
                Return sLanguageCode
            End Get
        End Property

        Public Overrides ReadOnly Property NumberOfSpecialisations() As Integer
            Get
                Return archetypeParser.Ontology.NumberOfSpecialisations
            End Get
        End Property

        Public Overrides Function LanguageAvailable(ByVal code As String) As Boolean
            Return archetypeParser.Ontology.LanguageAvailable(code)
        End Function

        Public Overrides Function TerminologyAvailable(ByVal code As String) As Boolean
            Return archetypeParser.Ontology.TerminologyAvailable(code)
        End Function

        Public Overrides Function TermForCode(ByVal Code As String, ByVal Language As String) As RmTerm

            If Code.ToLower(System.Globalization.CultureInfo.InvariantCulture).StartsWith("at") Then
                If archetypeParser.Ontology.HasTermCode(Code) Then
                    Return New XML_Classes.XML_Term(archetypeParser.Ontology.TermDefinition(Language, Code))
                End If
            ElseIf Code.ToLower(System.Globalization.CultureInfo.InvariantCulture).StartsWith("ac") Then
                If archetypeParser.Ontology.HasTermCode(Code) Then
                    Return New XML_Classes.XML_Term(archetypeParser.Ontology.ConstraintDefinition(Language, Code))
                End If
            Else
                Debug.Assert(False, "Code type is not available")
            End If

            Return Nothing
        End Function

        Public Overrides Function IsMultiLanguage() As Boolean
            Return archetypeParser.Ontology.AvailableLanguages.Count > 1
        End Function

        Public Overrides Sub Reset()
            ' no action required
            ' archetypeParser.ontology.clear_terminology()
        End Sub

        Public Overrides Sub AddLanguage(ByVal code As String)
            archetypeParser.Ontology.AddLanguage(code)
        End Sub

        Public Overrides Function HasTermBinding(ByVal a_terminology_id As String, ByVal a_path As String) As Boolean
            Return archetypeParser.Ontology.HasTermBinding(a_terminology_id, a_path)
        End Function

        Public Overrides Function HasConstraintBinding(ByVal a_terminology_id As String, ByVal a_path As String) As Boolean
            Return archetypeParser.Ontology.HasConstraintBinding(a_terminology_id, a_path)
        End Function

        Public Overrides Function TermBinding(ByVal a_terminology_id As String, ByVal a_path As String) As String
            Return archetypeParser.Ontology.TermBinding(a_terminology_id, a_path)
        End Function

        Public Overrides Function ConstraintBinding(ByVal a_terminology_id As String, ByVal a_path As String) As String
            Return archetypeParser.Ontology.ConstraintBinding(a_terminology_id, a_path)
        End Function

        Public Overrides Sub AddorReplaceTermBinding(ByVal terminologyId As String, ByVal archetypePath As String, ByVal sCode As String, ByVal sRelease As String)
            Debug.Assert(sCode <> "", "Code is not set")
            Debug.Assert(archetypePath <> "", "Path or nodeID are not set")
            Debug.Assert(terminologyId <> "", "TerminologyID is not set")

            Try
                Dim terminology_idValue As String = terminologyId

                If Not String.IsNullOrEmpty(sRelease) Then
                    terminology_idValue += "(" + sRelease + ")"
                End If

                archetypeParser.Ontology.AddOrReplaceTermBinding(sCode, archetypePath, terminologyId, terminology_idValue)
            Catch e As System.Exception
                MessageBox.Show(e.Message, "XML parser", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Public Overrides Sub RemoveTermBinding(ByVal terminologyId As String, ByVal archetypepath As String)
            Debug.Assert(archetypepath <> "", "Code is not set")
            Debug.Assert(terminologyId <> "", "TerminologyID is not set")

            Try
                If archetypeParser.Ontology.HasTermBinding(terminologyId, archetypepath) Then
                    archetypeParser.Ontology.RemoveTermBinding(archetypepath, terminologyId)
                End If
            Catch e As System.Exception
                MessageBox.Show(e.Message, "XML parser", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Public Overrides Sub AddorReplaceConstraintBinding(ByVal terminologyId As String, ByVal acCode As String, ByVal query As String)
            Debug.Assert(acCode <> "", "Code is not set")
            Debug.Assert(query <> "", "Query is not set")
            Debug.Assert(terminologyId <> "", "TerminologyID is not set")

            Try
                archetypeParser.Ontology.AddOrReplaceConstraintBinding(query, acCode, terminologyId)
            Catch e As System.Exception
                MessageBox.Show(e.Message, "XML parser", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Public Overrides Sub RemoveConstraintBinding(ByVal terminologyid As String, ByVal query As String)
            Debug.Assert(query <> "", "Code is not set")
            Debug.Assert(terminologyid <> "", "TerminologyID is not set")

            Try
                If archetypeParser.Ontology.HasConstraintBinding(terminologyid, query) Then
                    archetypeParser.Ontology.RemoveConstraintBinding(query, terminologyid)
                End If
            Catch e As System.Exception
                MessageBox.Show(e.Message, "XML Parser error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub

        Public Overrides Sub SetLanguage(ByVal language As String)
            sLanguageCode = language
            archetypeParser.Ontology.SetLanguage(language)
        End Sub

        Public Overrides Function SpecialiseTerm(ByVal Text As String, ByVal Description As String, ByVal Id As String) As RmTerm
            ' increase the number of specialisations
            Dim result As New XML_Term(NextSpecialisedId(Id))
            result.Text = Text
            result.Description = Description
            AddTerm(result)
            Return result
        End Function

        Public Overrides Sub SetPrimaryLanguage(ByVal language As String)
            ' sets the primary language of this archetype
            ' if this language is not in the available languages it adds it

            If language <> "" Then
                archetypeParser.Ontology.SetPrimaryLanguage(language)
            End If
        End Sub

        Public Overrides Function NextTermId() As String
            Dim result As String = ""

            Try
                result = archetypeParser.Ontology.NextTermId()
            Catch e As Exception
                Debug.Assert(False, e.Message)
            End Try

            Return result
        End Function

        Public Overrides Function NextConstraintId() As String
            Return archetypeParser.Ontology.NextConstraintId()
        End Function

        Private Function NextSpecialisedId(ByVal ParentCode As String) As String
            Return archetypeParser.Ontology.NextSpecialisedTermId(ParentCode)
        End Function

        Public Overrides Sub AddTerm(ByVal a_Term As RmTerm)
            Dim an_xml_Term As New XML_Term(a_Term)

            Try
                If Not archetypeParser.Ontology.HasTermCode(an_xml_Term.Code) Then
                    archetypeParser.Ontology.AddTermOrConstraintDefinition(sLanguageCode, an_xml_Term.XML_Term, False)
                Else
                    Debug.Assert(False)
                End If
            Catch e As Exception
                Debug.Assert(False, e.ToString)
            End Try
        End Sub

        Public Overrides Sub ReplaceTerm(ByVal a_Term As RmTerm, Optional ByVal ReplaceTranslations As Boolean = False)
            Dim language_code As String

            If Not a_Term.isConstraint Then
                If a_Term.Language <> "" Then
                    language_code = a_Term.Language
                Else
                    language_code = archetypeParser.Ontology.LanguageCode
                End If

                Try
                    If archetypeParser.Ontology.HasTermCode(a_Term.Code) Then
                        Dim term As New XML_Term(a_Term)
                        archetypeParser.Ontology.ReplaceTermDefinition(language_code, term.XML_Term, ReplaceTranslations)
                    Else
                        Debug.Assert(False, "Term code is not available: " & a_Term.Code)
                    End If
                Catch e As Exception
                    Debug.Assert(False, e.Message)
                End Try
            Else
                Debug.Assert(False, "Term is a constraint and should not be passed")
            End If
        End Sub

        Public Overrides Function HasTermCode(ByVal a_term_code As String) As Boolean
            If RmTerm.isValidTermCode(a_term_code) Then
                Return archetypeParser.Ontology.HasTermCode(a_term_code)
            End If
        End Function

        Public Overrides Sub AddConstraint(ByVal a_term As RmTerm)
            If a_term.isConstraint Then
                Try
                    If Not archetypeParser.Ontology.HasTermCode(a_term.Code) Then
                        archetypeParser.Ontology.AddTermOrConstraintDefinition( _
                            archetypeParser.Ontology.LanguageCode, _
                            New XML_Term(a_term).XML_Term, False)
                    Else
                        Debug.Assert(False, "Constraint code not available: " & a_term.Code)
                    End If
                Catch e As Exception
                    Debug.Assert(False, e.Message)
                End Try
            Else
                Debug.Assert(False, "Code is not a constraint code: " & a_term.Code)
            End If
        End Sub

        Public Sub AddTermDefinitionsFromTable(ByVal a_termdef_table As System.Data.DataTable)

            For Each data_row As System.Data.DataRow In a_termdef_table.Rows
                'Dim aTerm As New XML_Term(CStr(data_row(1)), CStr(data_row(2)), _
                '    CStr(data_row(3)), CStr(data_row(4)))
                Dim aTerm As New XML_Term(CType(data_row(5), RmTerm))
                archetypeParser.Ontology.AddTermOrConstraintDefinition(CStr(data_row(0)), aTerm.XML_Term, True)
            Next
        End Sub

        Public Sub AddTermBindingsFromTable(ByVal a_termBinding_table As System.Data.DataTable)
            Dim data_row As System.Data.DataRow
            For Each data_row In a_termBinding_table.Rows
                '                                                terminology id        code                path
                'archetypeParser.Ontology.AddOrReplaceTermBinding(CStr(data_row(2)), CStr(data_row(1)), CStr(data_row(0)))

                ' EDT-134
                Dim terminology_idValue As String = CStr(data_row(0))
                If Not data_row(3) Is Nothing AndAlso CStr(data_row(3)) <> "" Then
                    terminology_idValue += "(" + CStr(data_row(3)) + ")"
                End If
                archetypeParser.Ontology.AddOrReplaceTermBinding( _
                    CStr(data_row(2)), CStr(data_row(1)), CStr(data_row(0)), terminology_idValue)
                '   code_string,       archetype path,    terminology key,   terminology_id/value    
            Next
        End Sub

        Public Sub AddConstraintBindingsFromTable(ByVal constraintBindingTable As DataTable)
            Dim row As DataRow

            For Each row In constraintBindingTable.Rows
                archetypeParser.Ontology.AddOrReplaceConstraintBinding(CStr(row(4)), CStr(row(1)), CStr(row(0)))
            Next
        End Sub

        Public Sub AddConstraintDefinitionsFromTable(ByVal a_termdef_table As System.Data.DataTable)
            Dim data_row As System.Data.DataRow
            For Each data_row In a_termdef_table.Rows
                Dim aTerm As XML_Term = New XML_Term(CStr(data_row(1)), CStr(data_row(2)), CStr(data_row(3)))
                archetypeParser.Ontology.AddTermOrConstraintDefinition(CStr(data_row(0)), aTerm.XML_Term, True)
            Next
        End Sub

        Public Overrides Sub ReplaceConstraint(ByVal a_term As RmTerm, Optional ByVal ReplaceTranslations As Boolean = False)
            If a_term.IsConstraint Then
                Try
                    Dim xmlTerm As New XML_Term(a_term)

                    If archetypeParser.Ontology.HasTermCode(a_term.Code) Then
                        archetypeParser.Ontology.ReplaceTermDefinition( _
                            archetypeParser.Ontology.LanguageCode, xmlTerm.XML_Term, ReplaceTranslations)
                    Else
                        Debug.Assert(False, "Constraint code not available: " & a_term.Code)
                    End If
                Catch e As Exception
                    Debug.Assert(False, e.Message)
                End Try
            Else
                Debug.Assert(False, "Code is not a constraint code: " & a_term.Code)
            End If
        End Sub

        Public Sub populate_languages(ByRef ontologyManager As OntologyManager)
            If archetypeParser.Ontology.AvailableLanguages.Count > 0 Then
                'A new ontology always adds the current language - but this may not be available in the archetype
                ' so clear ..
                ontologyManager.LanguagesTable.Clear()

                For Each language As String In archetypeParser.Ontology.AvailableLanguages
                    ontologyManager.AddLanguage(language)
                Next
            End If
        End Sub

        Private Sub populate_terminologies(ByRef ontologyManager As OntologyManager)
            ' populate the terminology table in TermLookUp
            If archetypeParser.Ontology.AvailableTerminologies.Count > 0 Then
                For Each terminologyId As String In archetypeParser.Ontology.AvailableTerminologies
                    ontologyManager.AddTerminology(terminologyId)
                Next
            End If
        End Sub

        Private Sub populate_term_definitions(ByRef ontologyManager As OntologyManager, Optional ByVal LanguageCode As String = "")
            ' populate the TermDefinitions table in TermLookUp
            If archetypeParser.Archetype.ontology.term_definitions.Length > 0 Then
                Dim d_row As DataRow
                Dim a_term As XML_Classes.XML_Term

                For Each td As XMLParser.CodeDefinitionSet In archetypeParser.Archetype.ontology.term_definitions
                    If LanguageCode = "" Or td.language = LanguageCode Then
                        ' set the term for all languages
                        If Not td Is Nothing AndAlso (Not td.items Is Nothing) AndAlso (td.items.Length > 0) Then
                            For Each termDef As XMLParser.ARCHETYPE_TERM In td.items
                                a_term = New XML_Classes.XML_Term(termDef)
                                d_row = ontologyManager.TermDefinitionTable.NewRow
                                d_row(0) = td.language
                                d_row(1) = a_term.Code
                                d_row(2) = a_term.Text
                                d_row(3) = a_term.Description
                                d_row(4) = a_term.Comment
                                ' add it to the GUI ontology
                                d_row(5) = a_term
                                ontologyManager.TermDefinitionTable.Rows.Add(d_row)
                            Next
                        End If
                    End If
                Next
            End If
        End Sub

        Private Sub populate_term_bindings(ByRef ontologyManager As OntologyManager)
            ' populate the TermBindings table in TermLookUp
            If (Not archetypeParser.Archetype.ontology.term_bindings Is Nothing) AndAlso archetypeParser.Archetype.ontology.term_bindings.Length > 0 Then
                Dim d_row, selected_row As DataRow
                Dim terminology As String

                For Each selected_row In ontologyManager.TerminologiesTable.Rows
                    terminology = CStr(selected_row(0))
                    If archetypeParser.Ontology.TerminologyAvailable(terminology) Then
                        Dim ts As XMLParser.TermBindingSet = archetypeParser.Ontology.GetBindings(terminology, archetypeParser.Archetype.ontology.term_bindings)

                        'Can have terminologies which do not have bindings
                        If Not ts Is Nothing AndAlso (Not ts.items Is Nothing) AndAlso (ts.items.Length > 0) Then
                            Dim tab As DataTable = ontologyManager.TermBindingsTable
                            For Each bind As XMLParser.TERM_BINDING_ITEM In ts.items
                                d_row = tab.NewRow
                                d_row(0) = selected_row(0)
                                d_row(1) = bind.code

                                If Not bind.value Is Nothing Then
                                    If Not bind.value.terminology_id Is Nothing Then
                                        Dim strings() As String = bind.value.terminology_id.value.Split("("c)
                                        If strings.Length > 1 Then
                                            Dim release As String = strings(1).TrimEnd(")"c)
                                            d_row(3) = release
                                        End If
                                    End If

                                    d_row(2) = bind.value.code_string
                                End If

                                tab.Rows.Add(d_row)
                            Next
                        End If
                    End If
                Next
            End If
        End Sub

        Private Sub populate_constraint_definitions(ByRef ontologyManager As OntologyManager, Optional ByVal LanguageCode As String = "")
            ' populate the ConstraintDefinitions table in TermLookUp
            If (Not archetypeParser.Archetype.ontology.constraint_definitions Is Nothing) AndAlso archetypeParser.Archetype.ontology.constraint_definitions.Length > 0 Then
                Dim d_row As DataRow
                Dim a_term As XML_Classes.XML_Term

                For Each td As XMLParser.CodeDefinitionSet In archetypeParser.Archetype.ontology.constraint_definitions
                    If LanguageCode = "" Or td.language = LanguageCode Then
                        ' set the term for all languages
                        If Not td Is Nothing AndAlso (Not td.items Is Nothing) AndAlso (td.items.Length > 0) Then
                            For Each termDef As XMLParser.ARCHETYPE_TERM In td.items
                                a_term = New XML_Classes.XML_Term(termDef)
                                d_row = ontologyManager.ConstraintDefinitionTable.NewRow
                                d_row(0) = td.language
                                d_row(1) = a_term.Code
                                d_row(2) = a_term.Text
                                d_row(3) = a_term.Description
                                ' add it to the GUI ontology
                                ontologyManager.ConstraintDefinitionTable.Rows.Add(d_row)
                            Next
                        Else
                            Debug.Assert(False, "Constraint definitions exist but no terms")
                        End If
                    End If
                Next
            End If
        End Sub

        Private Function OntologyConstraintCodes() As ArrayList
            Dim result As New ArrayList

            If Not archetypeParser.Archetype.ontology.constraint_definitions Is Nothing Then
                Dim ls As XMLParser.CodeDefinitionSet = archetypeParser.Archetype.ontology.constraint_definitions(0)

                For Each t As XMLParser.ARCHETYPE_TERM In ls.items
                    result.Add(t.code)
                Next
            End If

            result.Sort()
            Return result
        End Function

        Private Function OntologyTermCodes() As ArrayList
            Dim result As New ArrayList

            If Not archetypeParser.Archetype.ontology.term_definitions Is Nothing Then
                Dim ls As XMLParser.CodeDefinitionSet = archetypeParser.Archetype.ontology.term_definitions(0)
                For Each t As XMLParser.ARCHETYPE_TERM In ls.items
                    result.Add(t.code)
                Next
            End If

            result.Sort()
            Return result
        End Function

        Private Sub populate_constraint_bindings(ByRef ontologyManager As OntologyManager)
            ' populate the ConstraintBindings table in TermLookUp
            Dim bindings As XMLParser.ConstraintBindingSet() = archetypeParser.Archetype.ontology.constraint_bindings

            If Not bindings Is Nothing AndAlso bindings.Length > 0 Then
                For Each terminologyRow As DataRow In ontologyManager.TerminologiesTable.Rows
                    Dim terminologyId As String = CStr(terminologyRow(0))

                    If archetypeParser.Ontology.TerminologyAvailable(terminologyId) Then
                        Dim bindingSet As XMLParser.ConstraintBindingSet = archetypeParser.Ontology.GetBindings(terminologyId, bindings)

                        If Not bindingSet Is Nothing AndAlso Not bindingSet.items Is Nothing Then
                            For Each bind As XMLParser.CONSTRAINT_BINDING_ITEM In bindingSet.items
                                ontologyManager.AddConstraintBinding(terminologyId, bind.code, bind.value)
                            Next
                        End If
                    End If
                Next
            End If
        End Sub

        Public Overrides Sub PopulateTermsInLanguage(ByRef ontologyManager As OntologyManager, ByVal LanguageCode As String)
            populate_term_definitions(ontologyManager, LanguageCode)
            populate_constraint_definitions(ontologyManager, LanguageCode)
        End Sub

        Public Overrides Sub PopulateAllTerms(ByRef ontologyManager As OntologyManager)
            If archetypeParser.ArchetypeAvailable Then
                populate_languages(ontologyManager)
                populate_terminologies(ontologyManager)
                populate_term_definitions(ontologyManager)
                populate_term_bindings(ontologyManager)
                populate_constraint_definitions(ontologyManager)
                populate_constraint_bindings(ontologyManager)
            End If
        End Sub

        Sub New(ByRef an_xml_parser As XMLParser.XmlArchetypeParser)
            archetypeParser = an_xml_parser
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
'The Original Code is XML_Ontology.vb.
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
