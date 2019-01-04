// Write your JavaScript code.

$(function () {
    if (Modernizr.inputtypes.date === false) {
        $('#BirthDate').datetimepicker({
            format: 'YYYY-MM-DD'
        });
    }
});

function showHideSecondLanguage(element)
{
    if (element.checked === true)
    {
        document.getElementById("secondLanguageForm").style.display = "block";
    }
    else
    {
        document.getElementById("secondLanguageForm").style.display = "none";
    }
}

function showHideSpouseExist(element)
{
    if (element.checked === true)
    {
        document.getElementById("spouseExistForm").style.display = "block";
    }
    else 
    {
        document.getElementById("spouseExistForm").style.display = "none";
    }
}

function showhideTypeOfExam(element)
{
    var index = element.selectedIndex;
    if (index > 0)
    {
        document.getElementById("examPointsForm").style.display = "block";
    }
    else
    {
        document.getElementById("examPointsForm").style.display = "none";
    }

    var sel = document.getElementById("TypeOfSecondExam");
    sel.options.length = 0;
    
    if (index === 1 || index === 2) {
        var opt1 = document.createElement("option");
        var opt2 = document.createElement("option");
        opt1.value = "3";
        opt1.text = "TEF Canada";
        opt2.value = "4";
        opt2.text = "TCF Canada";
        sel.add(opt1);
        sel.add(opt2);
    }
    else if (index === 3 || index === 4) {
        var opt1 = document.createElement("option");
        var opt2 = document.createElement("option");
        opt1.value = "1";
        opt1.text = "IELTS - General Training";
        opt2.value = "2";
        opt2.text = "CELPIP - General test";
        sel.add(opt1);
        sel.add(opt2);
    }
    else 
    {
        document.getElementById("SecondLanguage").checked = false;
        document.getElementById("secondLanguageForm").style.display = "none";
    }
}

function showhideTypeOfSpouseExam(element)
{
    var index = element.selectedIndex;
    if (index > 0) {
        document.getElementById("spouseExamPointsForm").style.display = "block";
    }
    else {
        document.getElementById("spouseExamPointsForm").style.display = "none";
    }
}