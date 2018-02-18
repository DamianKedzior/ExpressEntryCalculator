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
    
    if (index == 1) {
        var opt = document.createElement("option");
        opt.value = "3";
        opt.text = "TEF";
        sel.add(opt);
    }
    else if (index == 2) {
        var opt = document.createElement("option");
        opt.value = "3";
        opt.text = "TEF";
        sel.add(opt);
    }
    else if (index == 3) {
        var opt1 = document.createElement("option");
        var opt2 = document.createElement("option");
        opt1.value = "1";
        opt1.text = "IELTS";
        opt2.value = "2";
        opt2.text = "CELPIP";
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