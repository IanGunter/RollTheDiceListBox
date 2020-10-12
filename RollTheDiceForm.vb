'Ian Gunter
'RCET 0265
'RollTheDice
'Fall 2020
'

Public Class RollTheDiceForm

    Sub Rolldice()
        Dim randomNumber As Integer
        Dim numberrolled(10) As Integer
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
        Erase numberrolled
        ReDim numberrolled(10)

        RollDiceListBox.Items.Add("")
        RollDiceListBox.Items.Add("")



    End Sub

    'Function Generates a random number.
    Function GetRandomNumber(ByVal minimum As Single,
                             ByVal maximum As Single) As Single
        Dim diceOne As Single
        Dim diceTwo As Single
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
End Class



