'Student: Justo Dimabogti
'Student ID: 200188087
'Date: April 18, 2012
'Description: The form lets the user select Loads Character and New Character
'VERSION: 1.11 - StartForm 
'VERSION HISTORY:


Public Class StartForm


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadButton.Click
        'hides StartForm
        Me.Close()

        'shows ProductInfoForm
        CharacterBuilderForm.Show()

        'Call OpenFileDialog procedure
        'ProductInfoForm.OpenFileDialog()

    End Sub

    Private Sub NewButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewButton.Click
        'close start form
        Me.Close()
        'open characterbuilderform
        CharacterBuilderForm.Show()

    End Sub
End Class