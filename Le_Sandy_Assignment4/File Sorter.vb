Public Class Sorter
    ' Created by:           Sandy Le
    ' Course:               COIS-1520 WINTER2019
    ' Assignemnt:           Assignment #4 - Sorting
    ' Due Date:             April 5th, 2019 @ 23:59
    ' -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    ' 
    ' [Program Description]
    ' This program will act as a file reader and sorter. The main purpose of this program is to take the names from a textfile filled with names and have it be read into our listbox in our
    ' program, where we assume a maximum of 100 entries. Once these names are into our listbox, there will be two buttons that will be used to sort the list of names from one list box to
    ' another(sorted listbox). Those buttons being ascending and descending, where they will function as follows; sorting the names from the listbox to another listbox alphabetically either
    ' in ascending order (A-Za-z) or descending order (Z-Az-a).
    ' -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    '
    ' [Instructions]
    ' 1. Read names from names.txt by clicking on the 'Read Names' button.
    ' 2. Once read, you may do step one up to 100 entries. (because out names.txt is a fix size of 72, you may only read it twice. (and then it will prompt an error msg mid read as max entry is 100)
    ' 3. Either alphabetically sort for ascending order with the 'Ascending Order' button or sort descending through the 'Descending Order' button.
    ' 4. That is basically it for this program, exit button to close the program.
    ' -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    ' [Other Stuff]
    ' 1. Labels:
    '   a. 'rawLbl'                 - This abel is used to highlight and locate the listbox for read names.
    '   b. 'sortedLbl'              - This label is used to highlight and locate the listbox for the sorted names.
    '   c. 'contentAmountLbl'       - This label is used to represent the amount of entries read to the name list box
    '
    ' 2. ListBoxes:
    '   a. 'namesLstBox'            - This list box acts as a place to store the content/names read from a txt file.
    '   b. 'sortedLstBox'           - This list box acts as a place to store the sorted names.
    ' 
    ' 3. Buttons:
    '   a. 'readNamesBtn'           - Button used to read and add names from the text file to our names list box.
    '   b. 'ascendingBtn'           - Button used to take names from one list box and sort it alphabetically ascending to another list box.
    '   c. 'descendingBtn'          - Button used to take names from one list box and sort it alphabetically descending to another list box.
    '   d. 'exitBtn'                - Button used to close the program
    '
    '-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    ' Declaration of variables used throughout the program
    Dim counter As Integer = 0                  ' Variable count of int, used for counting the number of entries/names read in the listbox
    Dim fileReader As System.IO.StreamReader    ' filereader instance that will be used to read names.txt
    Dim names As String                         ' names as string, names directly pulled from names.txt

    Private Sub exitBtn_Click(sender As Object, e As EventArgs) Handles exitBtn.Click
        ' This subroutine allows for the function of the exitBtn when activated or clicked to close the program.
        Me.Close()
    End Sub

    Private Sub readNamesBtn_Click(sender As Object, e As EventArgs) Handles readNamesBtn.Click


        ' This will be used as a opentextfilereader, where it will read from names.txt
        ' note: edited a lowercase from name file, although I was unsure if it was placed there but it messed with my alogirthm when sorting due to the lower/upper case. And the assignment
        ' did not specify whether that was an issue or if it mattered.
        fileReader = My.Computer.FileSystem.OpenTextFileReader("D:\Le_Sandy_Assignment4\names.txt")

        ' This while loop will loop until filereader is at the end of stream.
        ' Thus reading all the names per line in the nameslistbox.
        While (Not (fileReader.EndOfStream))
            ' This if statement will only allow a maximum of 100 names, and will remove any names after the 100th entry.
            If (namesLstBox.Items.Count >= 100) Then
                names = fileReader.ReadLine()
                namesLstBox.Items.Remove(Name)
                ' The other condition where it will add regularly if it's equal to or less than 100 entries.
            ElseIf (namesLstBox.Items.Count <= 100) Then
                names = fileReader.ReadLine()
                namesLstBox.Items.Add(names)
                ' counter++ whenever a name is read, used to display entry amount below
                counter += 1
            End If
        End While

        ' An error will display once the user tries to read more than 100 names into the list box.
        ' For example, if you try to read the names.txt twice; because where's already more than 50+ names per read than it will prompt mid read but will still allow up to the 100th entry
        If (namesLstBox.Items.Count = 100) Then
            MsgBox("ERROR: You're now at the maximum capacity of names at 100.")
        End If

        ' Whenever the readNames button is activated, it will update the content amount label by taking the counter.
        contentAmountLbl.Text = "Content Amount: " & counter

    End Sub

    Private Sub ascendingBtn_Click(sender As Object, e As EventArgs) Handles ascendingBtn.Click

        ' Instantiation of a new list, that being our names from the listbox which was read from the txtfile.
        Dim names As New List(Of String)

        ' A For each loop, where for each name in the names Listbox, it will be added to this list of string.
        For Each item In namesLstBox.Items
            names.Add(item.ToString())
        Next

        ' Instantiation of the boolean being true that will be used for our While loop.
        Dim sort As Boolean = True
        ' This while loop will run until the sort is done by doing the loop untill swaps = true.
        While sort = True
            sort = False

            ' This if statement will sort the names in descending order by sorting through what is known as a bubble sort/skeleton sort mash up
            ' The algoirthm would use three variables where temp = names(i++), names (i++) = names(i) and names(i) = temp
            ' It will compare the next two elements in the list and will take the name with the higher value (in this case that value being alphabetical)
            For i As Integer = 0 To names.Count - 2
                If names(i) > names(i + 1) Then
                    Dim temp As String = names(i + 1)
                    names(i + 1) = names(i)
                    names(i) = temp
                    sort = True
                End If
            Next
        End While
        ' Will be added to sortedList Box
        sortedLstBox.DataSource = names


    End Sub

    Private Sub descendingBtn_Click(sender As Object, e As EventArgs) Handles descendingBtn.Click

        ' Instantiation of a new list, that being our names from the listbox which was read from the txtfile.
        Dim names As New List(Of String)

        ' A For each loop, where for each name in the names Listbox, it will be added to this list of string.
        For Each item In namesLstBox.Items
            names.Add(item.ToString())
        Next

        ' Instantiation of the boolean being true that will be used for our While loop.
        Dim sort As Boolean = True
        ' This while loop will run until the sort is done by doing the loop untill swaps = true.
        While sort = True
            sort = False

            ' This if statement will sort the names in descending order by sorting through what is known as a bubble sort/skeleton sort mash up
            ' The algoirthm would use three variables where temp = names(i++), names (i++) = names(i) and names(i) = temp
            ' It will compare the next two elements in the list/names and will leave the higher (in this case alphabetically) and take the one that's lower in alphabetically order.)
            For i As Integer = 0 To names.Count - 2
                If names(i) < names(i + 1) Then
                    Dim temp As String = names(i + 1)
                    names(i + 1) = names(i)
                    names(i) = temp
                    sort = True
                End If
            Next
        End While
        ' Will be added to the sorted list box
        sortedLstBox.DataSource = names

    End Sub
End Class