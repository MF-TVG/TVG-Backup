/// <reference path="~/GeneratedArtifacts/viewModel.js" />

myapp.BrowseContacts.AddContact_Tap_execute = function (screen) {
    // Write code here.
    myapp.showAddEditContact(null, {
        beforeShown: function (addEditScreen) {
            // Create a new contact here.
            var newContact = new myapp.Contact();
            addEditScreen.Contact = newContact;
        },
        afterClosed: function (addEditScreen, navigationAction) {
            // If the user commits the change, show the View screen
            if (navigationAction === msls.NavigateBackAction.commit) {
                var newContact = addEditScreen.Contact;
                myapp.showViewContact(newContact);
            }
        }
    })
};
myapp.BrowseContacts.Contact_postRender = function (element, contentItem) {
    // Write code here.
    contentItem.dataBind("value.Gender", function () {
        if (contentItem.value.Gender == "M") {
            $(element).addClass("male");
            $(element).removeClass("female");
        }

        else {
            $(element).addClass("female");
            $(element).removeClass("male");
        }
    });
};
myapp.BrowseContacts.Contacts1_render = function (element, contentItem) {
    // Write code here.
    // Instead of Screen, we passed Contacts as the contentItem.
    var contacts = contentItem.value;

    // Set up the callback function to fire after the data is loaded.
    contentItem.dataBind("value.isLoaded", function () {
        if (contacts.isLoaded) {
            // Create the HTML control
            var template = $("<b> " + contacts.count + " contacts found.</b>");
            // Append it to the DOM
            template.appendTo($(element));
        }
    });
};