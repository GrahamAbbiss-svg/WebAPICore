var EmployeeManagement = {
    variable: {
        //caseListContentgrid: $("#CaseListContent").data("kendoGrid"),
        //previewerDiv: $("#previewerDiv"),
        //pdfViewer: $("#pdfViewer"),
        //pdfDiv: $("#pdfDiv"),
        //downloadIFrame: $("#downloadIframe"),
        ContentDiv: $("#ContentDiv"),
        //caseFileUpload: $("#files").data("kendoUpload"),
        //btnAddFiles: $("#btnAddFiles"),
        //addFileWindow: $("#addFileWindow"),
        //addFileWindowContent: $("#addFileWindow .modal-content"),
        addNotesWindow: $("#addNotesWindow"),
        addNotesWindowContent: $("#addNotesWindow .modal-content"),
        promptsDiv: $("#promptsDiv"),
        //caseDetailsTabControl: $("#CaseDetailsTabstrip").data("kendoTabStrip")

    },

    url: {
        mycityUrl: document.location.protocol + "//" + document.location.host + "/Home/City",
        AddNoteUrl: document.location.protocol + "//" + document.location.host + "/Home/CaseNoteDetails",
        CategoryUrl: document.location.protocol + "//" + document.location.host + "/Home/CategoryChosen",
        DynamicUrl: document.location.protocol + "//" + document.location.host + "/Home/DynamicDropDown",
        DynamicUrl1: document.location.protocol + "//" + document.location.host + "/Home/DynamicDropDown1",
        Slider: document.location.protocol + "//" + document.location.host + "/Home/SliderValue",


    },
    promptSelect: function (SelectedLabId) {
        $.ajax({
            type: 'GET',
            cache: false,
            async: true,
            url: EmployeeManagement.url.CategoryUrl,
            data: 'SelectedCategorieID=' + SelectedLabId,
            success: function (result) {
                EmployeeManagement.variable.ContentDiv.html('');
                EmployeeManagement.variable.ContentDiv.html(result);
            }
        });
    },
    onSelectCity: function (e) {
       
        CityID =e;
        $.ajax({
            type: 'GET',
            cache: false,
            async: true,
            url: EmployeeManagement.url.mycityUrl,
            data: 'CityId=' + CityID,
            success: function (result) {
                EmployeeManagement.variable.ContentDiv.html('');
                EmployeeManagement.variable.ContentDiv.html(result);
            }
        });
    },
    onSelectSlider: function (e) {
        $.ajax({
            type: 'GET',
            cache: false,
            async: true,
            url: EmployeeManagement.url.Slider,
            data: 'Value=' + e,
            success: function (result) {
               
            }
        });
    },

  

    AddTextBox : function() {

    var div = document.createElement('DIV');

        div.innerHTML = '<div><input type="text" name="txttest" style="width:200px;" /><input type="button" onclick="RemoveTextBox(this)" value="Remove" /></div>';

    document.getElementById("divCont").appendChild(div);

    },

    displayNextDDL: function () {
        $.ajax({
            type: "GET",
            cache: false,
            async: true,
            url: EmployeeManagement.url.DynamicUrl,
            //data: "BookingTypeId=" + bookingTypeId + "&PromptId=" + promptId + "&OwnerPromptId=" + ownerPromptId + "&ChoiceId=" + choiceId,
            success: function (result) {
               
                EmployeeManagement.variable.promptsDiv.append(result);
               
            }
        });
    },

    displayNextDDL1: function (e) {
        $.ajax({
            type: "GET",
            cache: false,
            async: true,
            url: EmployeeManagement.url.DynamicUrl1,
            data: "BookingTypeId=" + e, 
            success: function (result) {

                EmployeeManagement.variable.promptsDiv.append(result);

            }
        });
    },
    displayNoteWindow: function (e) {

        var FileUrl = EmployeeManagement.url.AddNoteUrl + "?CityId=" + e;

        EmployeeManagement.variable.addNotesWindowContent.load(FileUrl, function () {
            EmployeeManagement.variable.addNotesWindow.modal({
                show: true,
                backdrop: 'static',
                keyboard: false,
                cache: false
            });
        });

        EmployeeManagement.variable.addNotesWindow.on("hidden.bs.modal", function () {
            EmployeeManagement.variable.addNotesWindow.find(".modal-content").html('');
        });

        $(EmployeeManagement.variable.addNotesWindow).off("submit");
        $(EmployeeManagement.variable.addNotesWindow).on("submit", "#formCaseNoteDetails", function (e) {
            e.preventDefault();

            var form = $(this);

            $.ajax({
                url: form.attr("action"),
                method: form.attr("method"),
                data: form.serialize(),
                success: function (partialResult) {
                    if (partialResult.success === true) {

                        document.getElementById("btnCancelNote").click();

                    }

                },
                error: function (e) {

                }
            });
        });

    },
}
