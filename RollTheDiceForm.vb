'Ian Gunter
'RCET 0265
'RollTheDice
'Fall 2020
'https://github.com/IanGunter/RollTheDiceListBox.git

Option Strict On
Option Explicit On
Option Compare Text

Public Class RollTheDiceForm
    Dim getHelp As String

    Sub Rolldice()
        Dim randomNumber As Integer
        Dim numberrolled(10) As Integer 'camelCase - TJR
        Dim text1 As String
        Dim text2 As String
        Dim listBoxText As String
        Dim formatDashes As String
        Randomize()

        'Rolls dice 1000 times
        For i = 1 To 1000

            randomNumber = CInt(GetRandomNumber(1, 6))
            numberrolled(randomNumber - 2) += 1

        Next


        'Formats location for text on console.
        For i = 2 To 12
            text1 = (text1 & String.Format("{0, 11}", i) & "|")
        Next
        RollDiceListBox.Items.Add(text1)

        'StrDup creates a specific amount of - for formatting console
        formatDashes = (StrDup(144, "-"))
        RollDiceListBox.Items.Add(formatDashes)

        For i = 0 To 10
            text2 = (text2 & String.Format("{0, 10}", numberrolled(i)) & "|")
        Next
        RollDiceListBox.Items.Add(text2)

        listBoxText = (text1 & vbNewLine & formatDashes & vbNewLine & text2)

        'Erases Array then redims it
        Erase numberrolled ' I think ReDim without Preserve clears the array - TJR
        ReDim numberrolled(10)

        RollDiceListBox.Items.Add("")
        RollDiceListBox.Items.Add("")

    End Sub

    'Function Generates a random number.
    Function GetRandomNumber(ByVal minimum As Single,
                             ByVal maximum As Single) As Single
        Dim diceOne As Double
        Dim diceTwo As Double
        Dim diceTotal As Single
        Do
            diceOne = ((maximum * Rnd()) + 0.5)
            diceTwo = ((maximum * Rnd()) + 0.5)

        Loop While diceOne < minimum - 0.5 Or diceOne >= maximum + 0.5 Or diceTwo < minimum - 0.5 Or diceTwo >= maximum + 0.5

        diceTotal = (CInt(diceOne) + CInt(diceTwo))

        Return CInt(diceTotal)
    End Function

    Private Sub RollButton_Click(sender As Object, e As EventArgs) Handles RollButton.Click
        Rolldice()
    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        RollDiceListBox.Items.Clear()
    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Private Sub RollToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RollToolStripMenuItem.Click
        Rolldice()
    End Sub

    Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem.Click
        RollDiceListBox.Items.Clear()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Public Sub StopGetSomeHelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StopGetSomeHelpToolStripMenuItem.Click
        getHelp = "Click buttons to do the things..."
        RollDiceListBox.Items.Add(getHelp)
        RollDiceListBox.Items.Add("")
        RollDiceListBox.Items.Add("")
    End Sub

    Private Sub RollTheDiceForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Enables hotkeys on startup 
        ActiveControl = RollButton ' ??? set Accept and Cancel Button in Form properties - TJR
    End Sub
End Class



