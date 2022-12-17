var HomeManagement = {

    variable: {
        ContentDiv: $("#ContentDiv"),
        CustomerDiv: $("#CustomerDiv"),
        GovernanceDiv: $("#GovernanceDiv"),
        PCDIDDiv: $("#PCDIDDiv"),
        addNotesWindow: $("#addNotesWindow"),
        addNotesWindowContent: $("#addNotesWindow .modal-content"),
        addStreamWindow: $("#addStreamWindow"),
        addStreamWindowContent: $("#addStreamWindow .modal-content"),
        DirectAssociationDiv: $("#DirectAssociationDiv"),
        addLoginWindow: $("#addLoginWindow"),
        addLoginWindowContent: $("#addLoginWindow .modal-content"),
        ErrorMessage: $("#ErrorMessage"),
        //promptsDiv: $("#promptsDiv"),

    },

    url: {
        CustomerURL: document.location.protocol + "//" + document.location.host + "/Entity/CustomerGroup",
        GovernaceGroupURL: document.location.protocol + "//" + document.location.host + "/Entity/GovernaceGroupDropDown",
        AddDirectActivityURL: document.location.protocol + "//" + document.location.host + "/PDA/AddDirectActivityReturnSection",
        DogsURL: document.location.protocol + "//" + document.location.host + "/PDA/Dogs",
        AddCusGovDetailsURL: document.location.protocol + "//" + document.location.host + "/PDA/AddCusGovDetails",
        GetCusGovDetails: document.location.protocol + "//" + document.location.host + "/PDA/GetCusGovDetails",
        AddNoteUrl: document.location.protocol + "//" + document.location.host + "/PDA/CaseNoteDetails",
        AddStreamList: document.location.protocol + "//" + document.location.host + "/Home/StreamListDetails",
        GetDirectAssociationList: document.location.protocol + "//" + document.location.host + "/PDA/DirectAssociation",
        GetHTML: document.location.protocol + "//" + document.location.host + "/Home/GetMyHtmlView",
        DropDown: document.location.protocol + "//" + document.location.host + "/Home/GetDropdownList",
        Login: document.location.protocol + "//" + document.location.host + "/Home/Login",
        CheckLogin: document.location.protocol + "//" + document.location.host + "/Home/CheckLogin",
        //DynamicUrl: document.location.protocol + "//" + document.location.host + "/Home/DynamicDropDown",
        //DynamicUrl1: document.location.protocol + "//" + document.location.host + "/Home/DynamicDropDown1",
        //Cache: document.location.protocol + "//" + document.location.host + "/Home/UpdateCache",

    },

    onCheckLogin: function () {

        $.ajax({
            type: 'GET',
            cache: false,
            async: true,
            url: HomeManagement.url.CheckLogin,
            success: function (result) {
                if (result.success === true) {

                    HomeManagement.displayLoginWindow();
                }

            }
        });
    },

    onSelectCustomer: function (e) {
        CustomerGroupID = e;
        $.ajax({
            type: 'GET',
            cache: false,
            async: true,
            url: EmployeeManagement.url.CustomerURL,
            data: 'CustomerGroupID=' + CustomerGroupID,
            success: function (result) {
                EmployeeManagement.variable.CustomerDiv.html('');
                EmployeeManagement.variable.CustomerDiv.html(result);
            }
        });

    },

    htmlSelect: function () {
        alert("Hit");
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

    onGetDogs: function () {

        $.ajax({
            type: 'GET',
            cache: false,
            async: true,
            url: EmployeeManagement.url.DogsURL,
            success: function (result) {
                EmployeeManagement.variable.ContentDiv.html('');
                EmployeeManagement.variable.ContentDiv.html(result);
            }
        });

    },

    onGetCusGovDetails: function () {

        $.ajax({
            type: 'GET',
            cache: false,
            async: true,
            url: EmployeeManagement.url.GetCusGovDetails,
            success: function (result) {
                EmployeeManagement.variable.ContentDiv.html('');
                EmployeeManagement.variable.ContentDiv.html(result);
            }
        });

    },

    onGetDirectAssociationList: function (e) {
        PcdID = e;
        $.ajax({
            type: 'GET',
            cache: false,
            async: true,
            url: EmployeeManagement.url.GetDirectAssociationList,
            data: 'PcdID=' + PcdID,
            success: function (result) {
                EmployeeManagement.variable.DirectAssociationDiv.html('');
                EmployeeManagement.variable.DirectAssociationDiv.html(result);
            }
        });

    },

    //displayNextDDL: function (e) {

    //    $.ajax({
    //        type: "GET",
    //        cache: false,
    //        async: true,
    //        url: HomeManagement.url.DynamicUrl,
    //        data: "BookingTypeId=" + e,
    //        //data: "BookingTypeId=" + bookingTypeId + "&PromptId=" + promptId + "&OwnerPromptId=" + ownerPromptId + "&ChoiceId=" + choiceId,
    //        success: function (result) {
    //            //EmployeeManagement.updateCache(0);
    //            HomeManagement.variable.promptsDiv.append(result);

    //        }
    //    });
    //},

    //displayNextDDL1: function (e, id) {
    //    var i;

    //    $.ajax({
    //        type: "GET",
    //        cache: false,
    //        async: true,
    //        url: HomeManagement.url.DynamicUrl1,
    //        data: "BookingTypeId=" + e,
    //        success: function (result) {

    //            if (result == "0") {
    //                id++;
    //                for (i = id; i < 5; i++) {

    //                    if (i != 2) {
    //                        $("#DynamicDiv" + i).remove();
    //                    }

    //                }

    //                HomeManagement.updateCache(id);
    //                HomeManagement.displayNextDDLUpdate(id);

    //            }
    //            else {
    //                HomeManagement.variable.promptsDiv.append(result);

    //            }

    //        }

    //    });

    //},
    //displayNextDDLUpdate: function (e) {

    //    e--;

    //    $.ajax({
    //        type: "GET",
    //        cache: false,
    //        async: true,
    //        url: HomeManagement.url.DynamicUrl1,
    //        data: "BookingTypeId=" + e,
    //        success: function (result) {
    //            HomeManagement.variable.promptsDiv.append(result);

    //        }

    //    });

    //},

    //updateCache: function (Id) {

    //    $.ajax({
    //        type: 'GET',
    //        cache: false,
    //        async: true,
    //        url: HomeManagement.url.Cache,
    //        data: 'Id' + Id,

    //        success: function (result) {
    //            HomeManagement.variable.ContentDiv.html('');
    //            HomeManagement.variable.ContentDiv.html(result);
    //        }
    //    });

    //},

    onSelectGovernance: function (e) {
        CustomerGroupID = e;
        $.ajax({
            type: 'GET',
            cache: false,
            async: true,
            url: EmployeeManagement.url.GovernaceGroupURL,
            data: 'CustomerGroupID=' + CustomerGroupID,
            success: function (result) {
                EmployeeManagement.variable.GovernanceDiv.html('');
                EmployeeManagement.variable.GovernanceDiv.html(result);
            }
        });

    },

    AddDirectActivity: function (employeePID, DirectTypeID, DirectActivityName, DirectActivityDescription, liveStatus) {

        DirectDetails = employeePID + ',' + DirectTypeID + ',' + DirectActivityName + ',' + DirectActivityDescription + ',' + liveStatus;

        $.ajax({
            type: 'GET',
            cache: false,
            async: true,
            url: EmployeeManagement.url.AddDirectActivityURL,
            data: 'DirectDetails=' + DirectDetails,
            success: function (result) {
                EmployeeManagement.variable.PCDIDDiv.html('');
                EmployeeManagement.variable.PCDIDDiv.html(result);
            }
        });

    },

    AddCustomerGovernanace: function (CustomerID, GovernanceID, PcdID, EmployeeID, DirectActivityID) {

        CusGovDetails = CustomerID + ',' + GovernanceID + ',' + PcdID + ',' + EmployeeID + ',' + DirectActivityID;

        $.ajax({
            type: 'GET',
            cache: false,
            async: true,
            url: EmployeeManagement.url.AddCusGovDetailsURL,
            data: 'CusGovDetails=' + CusGovDetails,
            success: function (result) {
                EmployeeManagement.variable.ContentDiv.html('');
                EmployeeManagement.variable.ContentDiv.html(result);
            }
        });

    },

    displayNoteWindow: function (e) {


        var FileUrl = EmployeeManagement.url.AddNoteUrl + "?PcdID=" + e;

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
                    //alert(partialResult.success);

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
        var FileUrl = HomeManagement.url.AddStreamList + "?PcdID=" + e;

        HomeManagement.variable.addStreamWindowContent.load(FileUrl, function () {
            HomeManagement.variable.addStreamWindow.modal({
                show: true,
                backdrop: 'static',
                keyboard: false,
                cache: false
            });
        });

        HomeManagement.variable.addStreamWindow.on("hidden.bs.modal", function () {
            HomeManagement.variable.addStreamWindow.find(".modal-content").html('');
        });

        $(HomeManagement.variable.addStreamWindow).off("submit");
        $(HomeManagement.variable.addStreamWindow).on("submit", "#formCaseNoteDetails", function (e) {

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

        
        var FileUrl = HomeManagement.url.Login

        HomeManagement.variable.addLoginWindowContent.load(FileUrl, function () {
            HomeManagement.variable.addLoginWindow.modal({
                show: true,
                backdrop: 'static',
                keyboard: false,
                cache: false
            });
        });

        HomeManagement.variable.addLoginWindow.on("hidden.bs.modal", function () {
            HomeManagement.variable.addLoginWindow.find(".modal-content").html('');
        });

        $(HomeManagement.variable.addLoginWindow).off("submit");
        $(HomeManagement.variable.addLoginWindow).on("submit", "#LoginModal", function (e) {

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
