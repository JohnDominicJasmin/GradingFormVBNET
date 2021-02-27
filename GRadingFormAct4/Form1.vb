



Public Class Dashboard





    Private Sub Submit_Button_Click(sender As Object, e As EventArgs) Handles Submit_Button.Click
        'returns 0 means false
        'else display the information 
        If (theAverageGradeis() = 0 Or checkIfUserLeaveBlankSpace()) Then
            MessageBox.Show("AN ENTRY IS REQUIRED OR HAS AN INVALID VALUE.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            MessageBox.Show("Student's Information: " & vbCrLf & studentInformation(firstnameLabel.Text.ToUpper.Trim, MiddlenameLabel.Text.ToUpper.Trim, LastnameLabel.Text.ToUpper.Trim, Bdate, ContactLabel.Text, Email_Label.Text, SectionLabel.Text.ToUpper, YearLevelComboBox.Text, SemesterComboBox.Text) & vbCrLf & "Average: " & theAverageGradeis() & "%" & "  " & gradeEquivalent(theAverageGradeis()), "STUDENT'S INFORMATION")
        End If
    End Sub





    Private Sub Close_Button_Click(sender As Object, e As EventArgs) Handles Close_Button.Click
        Application.Exit()
    End Sub
    'function call to clear input fields
    Private Sub Clear_Button_Click(sender As Object, e As EventArgs) Handles Clear_Button.Click
        clearFields()
        fnameLbl.Focus()
    End Sub









    'returns the student's information from following parameters parameters
    Function studentInformation(ByRef fname As String, ByRef mname As String, ByRef lname As String, ByRef birthday As DateTimePicker, ByRef contactNumber As String, ByRef email As String, ByRef section As String, ByRef yearlevel As String, ByRef semester As String) As String


        Dim Age As Integer = New DateTimePicker().Value.Year - birthday.Value.Year
        Dim RealAge As String = CStr(Age)


        Return "Full name: " + fname + " " + mname + " " + lname + vbCrLf + "Age: " + RealAge + vbCrLf + "Contact Number: " + contactNumber + vbCrLf + "Email Address: " + email + vbCrLf + "Year: " + yearlevel + vbCrLf + "Semester: " + semester
    End Function



    Function theAverageGradeis() As Integer


        ' using an array
        Dim Subjects() As String = {LinearAlgebraGrades_Label.Text, DSAGrades_Label.Text, IOTGrades_Label.Text, OOPGrade_Label.Text, SADGrades_Label.Text, NetworkingGrades_Label.Text, SoftEngrGrades_Label.Text, OperatingSystemGrades_Label.Text, RDBMSGRades_Label.Text, DiscreteMathGrades_Label.Text}
        Dim Grades As Double = 0.0

        'to iterate the array and get the total
        'using try-catch to handle error if user does not input in the given input fields
        Try
            For i As Integer = 0 To Subjects.Length - 1
                Grades += Double.Parse(Subjects(i)) / 10
            Next i

        Catch ex As System.FormatException

            Exit Function ' this returns 0  value immediately if there is an error, 0 value because there is no assign value yet to the variable'theAverageGradeis'

        End Try
        Return CStr(Grades)


    End Function


    'Check if user does not input anything
    Function checkIfUserLeaveBlankSpace() As Boolean

        Return firstnameLabel.TextLength = 0 Or MiddlenameLabel.TextLength = 0 Or LastnameLabel.TextLength = 0 Or ContactLabel.TextLength = 0 Or Email_Label.TextLength = 0 Or SectionLabel.TextLength = 0 Or YearLevelComboBox.Text.Equals("") Or SemesterComboBox.Text.Equals("")


    End Function

    ' set inputs to blankspace
    Sub clearFields()
        LinearAlgebraGrades_Label.ResetText()
        DSAGrades_Label.ResetText()
        IOTGrades_Label.ResetText()
        OOPGrade_Label.ResetText()
        SADGrades_Label.ResetText()
        NetworkingGrades_Label.ResetText()
        SoftEngrGrades_Label.ResetText()
        OperatingSystemGrades_Label.ResetText()
        RDBMSGRades_Label.ResetText()
        DiscreteMathGrades_Label.ResetText()
        firstnameLabel.ResetText()
        MiddlenameLabel.ResetText()
        LastnameLabel.ResetText()
        Bdate.ResetText()
        ContactLabel.ResetText()
        Email_Label.ResetText()
        SectionLabel.ResetText()
        YearLevelComboBox.Text = " "
        SemesterComboBox.Text = " "

    End Sub



    Function gradeEquivalent(ByVal totalGrade As Integer) As String
        Dim result As String


        'select what case and return the result
        Select Case totalGrade

            Case 97.0 To 100.0
                result = "---------------  1.0% PASSED  --------------- "

            Case 94.25 To 96.99
                result = "---------------  1.25% PASSED  --------------- "

            Case 91.5 To 94.24
                result = "---------------  1.5% PASSED  --------------- "

            Case 88.75 To 91.49
                result = "---------------  1.75% PASSED  --------------- "

            Case 86.0 To 88.74
                result = "---------------  2.0% PASSED  --------------- "

            Case 83.25 To 85.99
                result = "---------------  2.25% PASSED  ---------------"

            Case 80.5 To 83.24
                result = "---------------  2.5% PASSED  --------------- "

            Case 77.75 To 80.49
                result = "---------------  2.75% PASSED  --------------- "

            Case 75.0 To 77.74
                result = "---------------  3.0% PASSED  ---------------  "

            Case 0.00 To 74.99
                result = "---------------   INCOMPLETE  --------------- "

            Case 100.0 To 9999999
                result = "---------------   RESULT IS INVALID!  --------------- "
        End Select
        Return vbCrLf & vbCrLf & CStr(result)

    End Function

    'just a simple hover design
    Private Sub SubmitButtonEnter(sender As Object, e As EventArgs) Handles Submit_Button.MouseEnter
        Submit_Button.BackColor = Color.DarkGray
        Submit_Button.ForeColor = Color.White
    End Sub
    Private Sub SubmitButtonLeave(sender As Object, e As EventArgs) Handles Submit_Button.MouseLeave
        Submit_Button.BackColor = Color.FromArgb(128, 255, 128)
        Submit_Button.ForeColor = Color.Black
    End Sub

    Private Sub ClearButtonEnter(sender As Object, e As EventArgs) Handles Clear_Button.MouseEnter
        Clear_Button.BackColor = Color.Gray
        Clear_Button.ForeColor = Color.White
    End Sub
    Private Sub ClearButtonleave(sender As Object, e As EventArgs) Handles Clear_Button.MouseLeave
        Clear_Button.BackColor = Color.White
        Clear_Button.ForeColor = Color.Black
    End Sub
    Private Sub CloseButtonEnter(sender As Object, e As EventArgs) Handles Close_Button.MouseEnter

        Close_Button.BackColor = Color.DarkGray
        Close_Button.ForeColor = Color.White
    End Sub
    Private Sub CloseButtonleave(sender As Object, e As EventArgs) Handles Close_Button.MouseLeave
        Close_Button.BackColor = Color.FromArgb(255, 128, 128)
        Close_Button.ForeColor = Color.Black
    End Sub


End Class








