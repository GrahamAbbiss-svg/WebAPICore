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
        contacts: $("#contacts"),
        addStreamWindow: $("#addStreamWindow"),
        addStreamWindowContent: $("#addStreamWindow .modal-content"),
        addLoginWindow: $("#addLoginWindow"),
        addLoginWindowContent: $("#addLoginWindow .modal-content"),
        ErrorMessage: $("#ErrorMessage"),

    },

    url: {
        mycityUrl: document.location.protocol + "//" + document.location.host + "/Home/City",
        AddNoteUrl: document.location.protocol + "//" + document.location.host + "/Home/CaseNoteDetails",
        CategoryUrl: document.location.protocol + "//" + document.location.host + "/Home/CategoryChosen",
        DynamicUrl: document.location.protocol + "//" + document.location.host + "/Home/DynamicDropDown",
        DynamicUrl1: document.location.protocol + "//" + document.location.host + "/Home/DynamicDropDown1",
        Slider: document.location.protocol + "//" + document.location.host + "/Home/SliderValue",
        Angular: document.location.protocol + "//" + document.location.host + "/Home/AngularTest",
        GetHTML: document.location.protocol + "//" + document.location.host + "/Home/GetMyHtmlView",
        Contact: document.location.protocol + "//" + document.location.host + "/Home/Contacts",
        Cache: document.location.protocol + "//" + document.location.host + "/Home/UpdateCache",
        Json: document.location.protocol + "//" + document.location.host + "/Home/JSonPost",
        JsonStudent: document.location.protocol + "//" + document.location.host + "/Home/JSonStudent",
        AddStreamList: document.location.protocol + "//" + document.location.host + "/Home/StreamListDetails",
        CheckLogin: document.location.protocol + "//" + document.location.host + "/Home/CheckLogin",
        Login: document.location.protocol + "//" + document.location.host + "/Home/Login",


    },

    onCheckLogin: function () {

        $.ajax({
            type: 'GET',
            cache: false,
            async: true,
            url: EmployeeManagement.url.CheckLogin,
            success: function (result) {
                if (result.success === true) {

                    EmployeeManagement.displayLoginWindow();
                }

            }
        });
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

    JSonPost: function (values) {
        $.ajax({
            type: 'GET',
            cache: false,
            async: true,
            url: EmployeeManagement.url.Json,
            //data: 'node=' + values,
            data: 'node=' + JSON.stringify(values),
            success: function (result) {
               
            }
        });
    },

    JSonPostStudent: function (values) {
        $.ajax({
            type: 'POST',
            cache: false,
            async: true,
            url: EmployeeManagement.url.JsonStudent,
            //data: 'node=' + values,
            data: 'node=' + JSON.stringify(values),
            success: function (result) {

            }
        });
    },
    updateCache: function (Id) {
        
        $.ajax({
            type: 'GET',
            cache: false,
            async: true,
            url: EmployeeManagement.url.Cache,
            data: 'Id=' + Id,
            success: function (result) {
               
            }
        });
    },
    GetContact: function () {
        
        $.ajax({
            url: EmployeeManagement.url.Contact,
            type: "GET",
            contentType: "application/json; charset=utf-8",
            data: "{}",
            dataType: "json",
            success: function (data) {
                //alert(data);
                var obj = JSON.parse(data);
                var row = "";
                //alert(obj.Id[0]);
                
                //row += "<tr><td><input type='checkbox'id='" + obj[0].Id + "' name='chooseRecipient' class='my_chkBox' /></td><td>" + obj[0].Name + "</td><td>" + obj[0].MobileNumber + "</td></tr>";
                //row += "<tr><td><input type='checkbox'id='" + obj[1].Id + "' name='chooseRecipient' class='my_chkBox' /></td><td>" + obj[1].Name + "</td><td>" + obj[1].MobileNumber + "</td></tr>";
                //row += "<tr><td><input type='checkbox'id='" + obj[2].Id + "' name='chooseRecipient' class='my_chkBox' /></td><td>" + obj[2].Name + "</td><td>" + obj[2].MobileNumber + "</td></tr>";
                //$.each(data, function (index, item) {
                    
                    //row += "<tr><td><input type='checkbox'id='" + item.Id + "' name='chooseRecipient' class='my_chkBox' /></td><td>" + item.Name + "</td><td>" + item.MobileNumber + "</td></tr>";
                //});
                //alert(row);

                for (x in obj) {
                    row += "<tr><td><input type='checkbox'id='" + obj[x].Id + "' name='chooseRecipient' class='my_chkBox' /></td><td>" + obj[x].Name + "</td><td>" + obj[x].MobileNumber + "</td></tr>";
                     
                }
                $(EmployeeManagement.variable.contacts).html(row);
            },
            error: function (result) {
                alert("Error");
            }
        });
},


    htmlSelect: function () {
        $.ajax({
            type: 'GET',
            cache: false,
            async: true,
            url: EmployeeManagement.url.GetHTML,
            
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

        div.innerHTML = '<div><input type="text" name="txttest" style="width:200px;" /><input type="button" onclick="EmployeeManagement.RemoveTextBox(this)" value="Remove" /></div>';

    document.getElementById("divCont").appendChild(div);

    },

    RemoveTextBox: function (div) {
      
        document.getElementById("divCont").removeChild(div.parentNode);
       },


    //displayNextDDL: function () {
    //    $.ajax({
    //        type: "GET",
    //        cache: false,
    //        async: true,
    //        url: EmployeeManagement.url.DynamicUrl,
    //        //data: "BookingTypeId=" + bookingTypeId + "&PromptId=" + promptId + "&OwnerPromptId=" + ownerPromptId + "&ChoiceId=" + choiceId,
    //        success: function (result) {
               
    //            EmployeeManagement.variable.promptsDiv.append(result);
               
    //        }
    //    });
    //},
    displayNextDDL: function (e) {
        $.ajax({
            type: "GET",
            cache: false,
            async: true,
            url: EmployeeManagement.url.DynamicUrl,
            data: "BookingTypeId=" + e, 
            //data: "BookingTypeId=" + bookingTypeId + "&PromptId=" + promptId + "&OwnerPromptId=" + ownerPromptId + "&ChoiceId=" + choiceId,
            success: function (result) {
                
                EmployeeManagement.variable.promptsDiv.append(result);

            }
        });
    },

    displayNextDDL1: function (e,id) {
    
        $.ajax({
            type: "GET",
            cache: false,
            async: true,
            url: EmployeeManagement.url.DynamicUrl1,
            data: "BookingTypeId=" + e,
            success: function (result) {

                if (result == "0") {
                    id++;
                    for (i = id; i < 5; i++) {

                        if (i != 2) {
                            $("#DynamicDiv" + i).remove();
                        }
  
                    }

                    EmployeeManagement.updateCache(id);
                    EmployeeManagement.displayNextDDLUpdate(id);
                   
                }
                else {
                    EmployeeManagement.variable.promptsDiv.append(result);
                    
                }

            }

        });

    },
    displayNextDDLUpdate: function (e) {

        e--;

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

        var FileUrl = EmployeeManagement.url.AddNoteUrl+ "?CityId=" + e;

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

    displayStreamWindow: function (e) {


        var intPcdID = e;
        var FileUrl = EmployeeManagement.url.AddStreamList + "?PcdID=" + e;

        EmployeeManagement.variable.addStreamWindowContent.load(FileUrl, function () {
            EmployeeManagement.variable.addStreamWindow.modal({
                show: true,
                backdrop: 'static',
                keyboard: false,
                cache: false
            });
        });

        EmployeeManagement.variable.addStreamWindow.on("hidden.bs.modal", function () {
            EmployeeManagement.variable.addStreamWindow.find(".modal-content").html('');
        });

        $(EmployeeManagement.variable.addStreamWindow).off("submit");
        $(EmployeeManagement.variable.addStreamWindow).on("submit", "#formCaseNoteDetails", function (e) {

            e.preventDefault();

            var form = $(this);

            $.ajax({
                url: form.attr("action"),
                method: form.attr("method"),
                data: form.serialize(),
                success: function (partialResult) {


                    if (partialResult.success === true) {

                        document.getElementById("btnCancelNote").click();
                        document.getElementById("notemessage").click();

                    }

                },
                error: function (e) {


                }
            });
        });

    },

    displayLoginWindow: function () {

        
        var FileUrl = EmployeeManagement.url.Login
        
        EmployeeManagement.variable.addLoginWindowContent.load(FileUrl, function () {
            EmployeeManagement.variable.addLoginWindow.modal({
                show: true,
                backdrop: 'static',
                keyboard: false,
                cache: false
            });
        });

        EmployeeManagement.variable.addLoginWindow.on("hidden.bs.modal", function () {
            EmployeeManagement.variable.addLoginWindow.find(".modal-content").html('');
        });

        $(EmployeeManagement.variable.addLoginWindow).off("submit");
        $(EmployeeManagement.variable.addLoginWindow).on("submit", "#LoginModal", function (e) {

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
                    else {

                        $('#ErrorMessage').text('User name and Password are incorrect')
                    }

                },
                error: function (e) {


                }
            });
        });

    },
}
