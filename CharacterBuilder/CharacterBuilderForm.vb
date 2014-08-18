'Student: Justo Dimabogti
'Student ID: 200188087
'Date: April 18, 2012
'Description:  Form - tabbed form that allows the user to choose his character race,
'class, roll his abilities, allocate his skills and populate informatio.
'VERSION: 1.11 - CharacterBuilderForm 
'VERSION HISTORY:


Imports System.IO

Friend Class CharacterBuilderForm
    ' form level declarations
    Protected Friend CHARLevel As String = "1"
    Protected Friend CHARGender As String = "Male"
    Protected Friend CHARSTR As String
    Protected Friend CHARDEX As String
    Protected Friend CHARCON As String
    Protected Friend CHARWIS As String
    Protected Friend CHARINT As String
    Protected Friend CHARCHA As String

    Private Function AbilityModifier(ByVal Ability As Integer)
        ' Calculate ability modifier
        Return Math.Floor(Ability / 2) - 5
    End Function

    Private Sub MaleRadioButton_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles MaleRadioButton.CheckedChanged
        CHARGender = "Male"
    End Sub

    Private Sub FemaleRadioButton_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles FemaleRadioButton.CheckedChanged
        CHARGender = "Female"
    End Sub

    Private Sub ContinueButton1_Click(sender As System.Object, e As System.EventArgs) Handles ContinueButton1.Click
        'display tabcobrol1
        TabControl1.SelectedIndex = 1
    End Sub

    Private Sub ContinueButton2_Click(sender As System.Object, e As System.EventArgs) Handles ContinueButton2.Click
        TabControl1.SelectedIndex = 2
    End Sub

    Private Sub ContinueButton3_Click(sender As System.Object, e As System.EventArgs) Handles ContinueButton3.Click
        TabControl1.SelectedIndex = 3

    End Sub


    Private Sub STRTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles STRTextBox.TextChanged
        CHARSTR = STRTextBox.Text
        If Not (STRTextBox.Text = "") And Not (STRTextBox.Text = "+ 2") Then
            STRMODTextBox.Text = AbilityModifier(Integer.Parse(CHARSTR))
            STRMODLVLTextBox.Text = (Integer.Parse(STRMODTextBox.Text) + Math.Floor(Integer.Parse(CHARLevel) / 2)).ToString()
        End If

    End Sub

    Private Sub DEXTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles DEXTextBox.TextChanged
        If Not (DEXTextBox.Text = "") Then
            CHARDEX = DEXTextBox.Text
            DEXMODTextBox.Text = AbilityModifier(Integer.Parse(CHARDEX))
            DEXMODLVLTextBox.Text = (Integer.Parse(DEXMODTextBox.Text) + Math.Floor(Integer.Parse(CHARLevel) / 2)).ToString()
        End If

    End Sub

    Private Sub CONTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles CONTextBox.TextChanged
        If Not (CONTextBox.Text = "") Then
            CHARCON = CONTextBox.Text
            CONMODTextBox.Text = AbilityModifier(Integer.Parse(CHARCON))
            CONMODLVLTextBox.Text = (Integer.Parse(CONMODTextBox.Text) + Math.Floor(Integer.Parse(CHARLevel) / 2)).ToString()
        End If

    End Sub

    Private Sub WISTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles WISTextBox.TextChanged
        If Not (WISTextBox.Text = "") Then
            CHARWIS = WISTextBox.Text
            WISMODTextBox.Text = AbilityModifier(Integer.Parse(CHARWIS))
            WISMODLVLTextBox.Text = (Integer.Parse(WISMODTextBox.Text) + Math.Floor(Integer.Parse(CHARLevel) / 2)).ToString()
        End If

    End Sub

    Private Sub INTTextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles INTTextBox.TextChanged
        If Not (INTTextBox.Text = "") Then
            CHARINT = INTTextBox.Text
            INTMODTextBox.Text = AbilityModifier(Integer.Parse(CHARINT))
            INTMODLVLTextBox.Text = (Integer.Parse(INTMODTextBox.Text) + Math.Floor(Integer.Parse(CHARLevel) / 2)).ToString()
        End If

    End Sub

    Private Sub CHATextBox_TextChanged(sender As System.Object, e As System.EventArgs) Handles CHATextBox.TextChanged
        If Not (CHATextBox.Text = "") Then
            CHARCHA = CHATextBox.Text
            CHAMODTextBox.Text = AbilityModifier(Integer.Parse(CHARCHA))
            CHAMODLVLTextBox.Text = (Integer.Parse(CHAMODTextBox.Text) + Math.Floor(Integer.Parse(CHARLevel) / 2)).ToString()
        End If

    End Sub

    Private Sub RaceBindingNavigatorSaveItem_Click(sender As System.Object, e As System.EventArgs)
        Me.Validate()
        Me.RaceBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.CharacterbuilderDataSet)

    End Sub
    'initialize skipcenter
    Private skipCellenter As Boolean

    Private Sub CharacterForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Dropping must be enabled before the dragging occurs.
        STRTextBox.AllowDrop = True
        DEXTextBox.AllowDrop = True


        'TODO: This line of code loads data into the 'CharacterbuilderDataSet._class' table. You can move, or remove it, as needed.
        Me.ClassTableAdapter.Fill(Me.CharacterbuilderDataSet._class)
        'TODO: This line of code loads data into the 'CharacterbuilderDataSet.race' table. You can move, or remove it, as needed.
        Me.RaceTableAdapter.Fill(Me.CharacterbuilderDataSet.race)

        skipCellenter = False

        DataGridView1.SelectedRows(0).Selected = False

    End Sub

    Private Sub DataGridView1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEnter

        If skipCellenter = False Then
            'If not selected header row
            If e.RowIndex <> -1 Then
                '    CopyRowData(e.RowIndex)
                '        NextButton.Enabled = True
            End If
        End If
    End Sub

    Private Sub DataGridView1_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.RowEnter
        'highlighting whole row
        DataGridView1.Rows(e.RowIndex).Selected = True
    End Sub

    'Randomized
    Friend Function Rand(ByVal Low As Long, _
            ByVal High As Long) As Long
        Rand = Int((High - Low + 1) * Rnd()) + Low
    End Function

    Private Sub RollButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RollButton.Click

        RNDTextBox1.Text = Rand(4, 10)
        RNDTextBox2.Text = Rand(4, 10)
        RNDTextBox3.Text = Rand(4, 10)
        RNDTextBox4.Text = Rand(4, 10)
        RNDTextBox5.Text = Rand(4, 10)
        RNDTextBox6.Text = Rand(4, 10)

        RNDTextBox1.Text = Rand(6, 10)
        RNDTextBox2.Text = Rand(6, 10)
        RNDTextBox3.Text = Rand(6, 10)
        RNDTextBox4.Text = Rand(6, 10)
        RNDTextBox5.Text = Rand(6, 10)
        RNDTextBox6.Text = Rand(6, 10)
    End Sub

    'SOURCE
    Private Sub RNDTextBox1_MouseDown(ByVal sender As Object, ByVal e _
    As System.Windows.Forms.MouseEventArgs) Handles RNDTextBox1.MouseDown

        RNDTextBox1.DoDragDrop(RNDTextBox1.Text, DragDropEffects.Move)

    End Sub

    'DESTINATION
    Private Sub ToTextBox1_DragEnter(ByVal sender As Object, ByVal e _
    As System.Windows.Forms.DragEventArgs) Handles STRRaceTextBox.DragEnter


        ' Make sure that the format is text.
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            ' Allow drop.
            'e.Effect = DragDropEffects.Copy
            e.Effect = DragDropEffects.Move
        Else
            ' Do not allow drop.
            e.Effect = DragDropEffects.None
        End If
    End Sub



    Private Sub STRTextBox_DragDrop(ByVal sender As Object, ByVal e _
  As System.Windows.Forms.DragEventArgs) Handles STRTextBox.DragDrop

        ' Copy the text to the second TextBox.
        STRTextBox.Text = e.Data.GetData(DataFormats.Text).ToString

        STRTextBox.Enabled = False
        ' FromTextBox1.Clear()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        AboutBox1.Show()

    End Sub


    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        'executes FileDialog() procedures
        OpenFileDialog()
    End Sub

    Public Sub OpenFileDialog()
        ' Display the File Open dialog box.
        OpenFileDialog1.InitialDirectory = Directory.GetCurrentDirectory

        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            'Read into array
            Dim sr As New StreamReader(OpenFileDialog1.FileName)
            Dim tmpline As String = sr.ReadLine

            
            sr.Close()

            '
        End If

    End Sub
  

End Class
