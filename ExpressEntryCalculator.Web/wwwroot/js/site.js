// Write your JavaScript code.

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
    //var element = document.getElementById('SpouseExist');
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