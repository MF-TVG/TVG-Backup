/// <reference path="data.js" />

(function (lightSwitchApplication) {

    var $Screen = msls.Screen,
        $defineScreen = msls._defineScreen,
        $DataServiceQuery = msls.DataServiceQuery,
        $toODataString = msls._toODataString,
        $defineShowScreen = msls._defineShowScreen;

    function BrowseContacts(parameters, dataWorkspace) {
        /// <summary>
        /// Represents the BrowseContacts screen.
        /// </summary>
        /// <param name="parameters" type="Array">
        /// An array of screen parameter values.
        /// </param>
        /// <param name="dataWorkspace" type="msls.application.DataWorkspace" optional="true">
        /// An existing data workspace for this screen to use. By default, a new data workspace is created.
        /// </param>
        /// <field name="Contacts" type="msls.VisualCollection" elementType="msls.application.Contact">
        /// Gets the contacts for this screen.
        /// </field>
        /// <field name="FindContact" type="String">
        /// Gets or sets the findContact for this screen.
        /// </field>
        /// <field name="ContactMinimumBirthDate" type="Date">
        /// Gets or sets the contactMinimumBirthDate for this screen.
        /// </field>
        /// <field name="ContactMaximumBirthDate" type="Date">
        /// Gets or sets the contactMaximumBirthDate for this screen.
        /// </field>
        /// <field name="details" type="msls.application.BrowseContacts.Details">
        /// Gets the details for this screen.
        /// </field>
        if (!dataWorkspace) {
            dataWorkspace = new lightSwitchApplication.DataWorkspace();
        }
        $Screen.call(this, dataWorkspace, "BrowseContacts", parameters);
    }

    function AddEditContact(parameters, dataWorkspace) {
        /// <summary>
        /// Represents the AddEditContact screen.
        /// </summary>
        /// <param name="parameters" type="Array">
        /// An array of screen parameter values.
        /// </param>
        /// <param name="dataWorkspace" type="msls.application.DataWorkspace" optional="true">
        /// An existing data workspace for this screen to use. By default, a new data workspace is created.
        /// </param>
        /// <field name="Contact" type="msls.application.Contact">
        /// Gets or sets the contact for this screen.
        /// </field>
        /// <field name="details" type="msls.application.AddEditContact.Details">
        /// Gets the details for this screen.
        /// </field>
        if (!dataWorkspace) {
            dataWorkspace = new lightSwitchApplication.DataWorkspace();
        }
        $Screen.call(this, dataWorkspace, "AddEditContact", parameters);
    }

    function ViewContact(parameters, dataWorkspace) {
        /// <summary>
        /// Represents the ViewContact screen.
        /// </summary>
        /// <param name="parameters" type="Array">
        /// An array of screen parameter values.
        /// </param>
        /// <param name="dataWorkspace" type="msls.application.DataWorkspace" optional="true">
        /// An existing data workspace for this screen to use. By default, a new data workspace is created.
        /// </param>
        /// <field name="Contact" type="msls.application.Contact">
        /// Gets or sets the contact for this screen.
        /// </field>
        /// <field name="EmailAddresses" type="msls.VisualCollection" elementType="msls.application.EmailAddress">
        /// Gets the emailAddresses for this screen.
        /// </field>
        /// <field name="PhoneNumbers" type="msls.VisualCollection" elementType="msls.application.PhoneNumber">
        /// Gets the phoneNumbers for this screen.
        /// </field>
        /// <field name="Addresses" type="msls.VisualCollection" elementType="msls.application.Address">
        /// Gets the addresses for this screen.
        /// </field>
        /// <field name="details" type="msls.application.ViewContact.Details">
        /// Gets the details for this screen.
        /// </field>
        if (!dataWorkspace) {
            dataWorkspace = new lightSwitchApplication.DataWorkspace();
        }
        $Screen.call(this, dataWorkspace, "ViewContact", parameters);
    }

    function AddEditEmailAddress(parameters, dataWorkspace) {
        /// <summary>
        /// Represents the AddEditEmailAddress screen.
        /// </summary>
        /// <param name="parameters" type="Array">
        /// An array of screen parameter values.
        /// </param>
        /// <param name="dataWorkspace" type="msls.application.DataWorkspace" optional="true">
        /// An existing data workspace for this screen to use. By default, a new data workspace is created.
        /// </param>
        /// <field name="EmailAddress" type="msls.application.EmailAddress">
        /// Gets or sets the emailAddress for this screen.
        /// </field>
        /// <field name="details" type="msls.application.AddEditEmailAddress.Details">
        /// Gets the details for this screen.
        /// </field>
        if (!dataWorkspace) {
            dataWorkspace = new lightSwitchApplication.DataWorkspace();
        }
        $Screen.call(this, dataWorkspace, "AddEditEmailAddress", parameters);
    }

    function AddEditPhoneNumber(parameters, dataWorkspace) {
        /// <summary>
        /// Represents the AddEditPhoneNumber screen.
        /// </summary>
        /// <param name="parameters" type="Array">
        /// An array of screen parameter values.
        /// </param>
        /// <param name="dataWorkspace" type="msls.application.DataWorkspace" optional="true">
        /// An existing data workspace for this screen to use. By default, a new data workspace is created.
        /// </param>
        /// <field name="PhoneNumber" type="msls.application.PhoneNumber">
        /// Gets or sets the phoneNumber for this screen.
        /// </field>
        /// <field name="details" type="msls.application.AddEditPhoneNumber.Details">
        /// Gets the details for this screen.
        /// </field>
        if (!dataWorkspace) {
            dataWorkspace = new lightSwitchApplication.DataWorkspace();
        }
        $Screen.call(this, dataWorkspace, "AddEditPhoneNumber", parameters);
    }

    function AddEditAddress(parameters, dataWorkspace) {
        /// <summary>
        /// Represents the AddEditAddress screen.
        /// </summary>
        /// <param name="parameters" type="Array">
        /// An array of screen parameter values.
        /// </param>
        /// <param name="dataWorkspace" type="msls.application.DataWorkspace" optional="true">
        /// An existing data workspace for this screen to use. By default, a new data workspace is created.
        /// </param>
        /// <field name="Address" type="msls.application.Address">
        /// Gets or sets the address for this screen.
        /// </field>
        /// <field name="details" type="msls.application.AddEditAddress.Details">
        /// Gets the details for this screen.
        /// </field>
        if (!dataWorkspace) {
            dataWorkspace = new lightSwitchApplication.DataWorkspace();
        }
        $Screen.call(this, dataWorkspace, "AddEditAddress", parameters);
    }

    function BrowseContactsByPhone(parameters, dataWorkspace) {
        /// <summary>
        /// Represents the BrowseContactsByPhone screen.
        /// </summary>
        /// <param name="parameters" type="Array">
        /// An array of screen parameter values.
        /// </param>
        /// <param name="dataWorkspace" type="msls.application.DataWorkspace" optional="true">
        /// An existing data workspace for this screen to use. By default, a new data workspace is created.
        /// </param>
        /// <field name="ContactsByPhone" type="msls.VisualCollection" elementType="msls.application.PhoneNumber">
        /// Gets the contactsByPhone for this screen.
        /// </field>
        /// <field name="PhoneNumberFindContact" type="String">
        /// Gets or sets the phoneNumberFindContact for this screen.
        /// </field>
        /// <field name="details" type="msls.application.BrowseContactsByPhone.Details">
        /// Gets the details for this screen.
        /// </field>
        if (!dataWorkspace) {
            dataWorkspace = new lightSwitchApplication.DataWorkspace();
        }
        $Screen.call(this, dataWorkspace, "BrowseContactsByPhone", parameters);
    }

    msls._addToNamespace("msls.application", {

        BrowseContacts: $defineScreen(BrowseContacts, [
            {
                name: "Contacts", kind: "collection", elementType: lightSwitchApplication.Contact,
                createQuery: function (MinimumBirthDate, MaximumBirthDate) {
                    return this.dataWorkspace.ApplicationData.ContactsByBirthDate(MinimumBirthDate, MaximumBirthDate);
                }
            },
            { name: "FindContact", kind: "local", type: String },
            { name: "ContactMinimumBirthDate", kind: "local", type: Date },
            { name: "ContactMaximumBirthDate", kind: "local", type: Date }
        ], [
            { name: "AddContact_Tap" }
        ]),

        AddEditContact: $defineScreen(AddEditContact, [
            { name: "Contact", kind: "local", type: lightSwitchApplication.Contact }
        ], [
        ]),

        ViewContact: $defineScreen(ViewContact, [
            { name: "Contact", kind: "local", type: lightSwitchApplication.Contact },
            {
                name: "EmailAddresses", kind: "collection", elementType: lightSwitchApplication.EmailAddress,
                getNavigationProperty: function () {
                    if (this.owner.Contact) {
                        return this.owner.Contact.details.properties.EmailAddresses;
                    }
                    return null;
                },
                appendQuery: function () {
                    return this;
                }
            },
            {
                name: "PhoneNumbers", kind: "collection", elementType: lightSwitchApplication.PhoneNumber,
                getNavigationProperty: function () {
                    if (this.owner.Contact) {
                        return this.owner.Contact.details.properties.PhoneNumbers;
                    }
                    return null;
                },
                appendQuery: function () {
                    return this;
                }
            },
            {
                name: "Addresses", kind: "collection", elementType: lightSwitchApplication.Address,
                getNavigationProperty: function () {
                    if (this.owner.Contact) {
                        return this.owner.Contact.details.properties.Addresses;
                    }
                    return null;
                },
                appendQuery: function () {
                    return this;
                }
            }
        ], [
        ]),

        AddEditEmailAddress: $defineScreen(AddEditEmailAddress, [
            { name: "EmailAddress", kind: "local", type: lightSwitchApplication.EmailAddress }
        ], [
        ]),

        AddEditPhoneNumber: $defineScreen(AddEditPhoneNumber, [
            { name: "PhoneNumber", kind: "local", type: lightSwitchApplication.PhoneNumber }
        ], [
        ]),

        AddEditAddress: $defineScreen(AddEditAddress, [
            { name: "Address", kind: "local", type: lightSwitchApplication.Address }
        ], [
        ]),

        BrowseContactsByPhone: $defineScreen(BrowseContactsByPhone, [
            {
                name: "ContactsByPhone", kind: "collection", elementType: lightSwitchApplication.PhoneNumber,
                createQuery: function (FindContact) {
                    return this.dataWorkspace.ApplicationData.ContactsByPhone(FindContact).expand("Contact");
                }
            },
            { name: "PhoneNumberFindContact", kind: "local", type: String }
        ], [
        ]),

        showBrowseContacts: $defineShowScreen(function showBrowseContacts(options) {
            /// <summary>
            /// Asynchronously navigates forward to the BrowseContacts screen.
            /// </summary>
            /// <param name="options" optional="true">
            /// An object that provides one or more of the following options:<br/>- beforeShown: a function that is called after boundary behavior has been applied but before the screen is shown.<br/>+ Signature: beforeShown(screen)<br/>- afterClosed: a function that is called after boundary behavior has been applied and the screen has been closed.<br/>+ Signature: afterClosed(screen, action : msls.NavigateBackAction)
            /// </param>
            /// <returns type="WinJS.Promise" />
            var parameters = Array.prototype.slice.call(arguments, 0, 0);
            return lightSwitchApplication.showScreen("BrowseContacts", parameters, options);
        }),

        showAddEditContact: $defineShowScreen(function showAddEditContact(Contact, options) {
            /// <summary>
            /// Asynchronously navigates forward to the AddEditContact screen.
            /// </summary>
            /// <param name="options" optional="true">
            /// An object that provides one or more of the following options:<br/>- beforeShown: a function that is called after boundary behavior has been applied but before the screen is shown.<br/>+ Signature: beforeShown(screen)<br/>- afterClosed: a function that is called after boundary behavior has been applied and the screen has been closed.<br/>+ Signature: afterClosed(screen, action : msls.NavigateBackAction)
            /// </param>
            /// <returns type="WinJS.Promise" />
            var parameters = Array.prototype.slice.call(arguments, 0, 1);
            return lightSwitchApplication.showScreen("AddEditContact", parameters, options);
        }),

        showViewContact: $defineShowScreen(function showViewContact(Contact, options) {
            /// <summary>
            /// Asynchronously navigates forward to the ViewContact screen.
            /// </summary>
            /// <param name="options" optional="true">
            /// An object that provides one or more of the following options:<br/>- beforeShown: a function that is called after boundary behavior has been applied but before the screen is shown.<br/>+ Signature: beforeShown(screen)<br/>- afterClosed: a function that is called after boundary behavior has been applied and the screen has been closed.<br/>+ Signature: afterClosed(screen, action : msls.NavigateBackAction)
            /// </param>
            /// <returns type="WinJS.Promise" />
            var parameters = Array.prototype.slice.call(arguments, 0, 1);
            return lightSwitchApplication.showScreen("ViewContact", parameters, options);
        }),

        showAddEditEmailAddress: $defineShowScreen(function showAddEditEmailAddress(EmailAddress, options) {
            /// <summary>
            /// Asynchronously navigates forward to the AddEditEmailAddress screen.
            /// </summary>
            /// <param name="options" optional="true">
            /// An object that provides one or more of the following options:<br/>- beforeShown: a function that is called after boundary behavior has been applied but before the screen is shown.<br/>+ Signature: beforeShown(screen)<br/>- afterClosed: a function that is called after boundary behavior has been applied and the screen has been closed.<br/>+ Signature: afterClosed(screen, action : msls.NavigateBackAction)
            /// </param>
            /// <returns type="WinJS.Promise" />
            var parameters = Array.prototype.slice.call(arguments, 0, 1);
            return lightSwitchApplication.showScreen("AddEditEmailAddress", parameters, options);
        }),

        showAddEditPhoneNumber: $defineShowScreen(function showAddEditPhoneNumber(PhoneNumber, options) {
            /// <summary>
            /// Asynchronously navigates forward to the AddEditPhoneNumber screen.
            /// </summary>
            /// <param name="options" optional="true">
            /// An object that provides one or more of the following options:<br/>- beforeShown: a function that is called after boundary behavior has been applied but before the screen is shown.<br/>+ Signature: beforeShown(screen)<br/>- afterClosed: a function that is called after boundary behavior has been applied and the screen has been closed.<br/>+ Signature: afterClosed(screen, action : msls.NavigateBackAction)
            /// </param>
            /// <returns type="WinJS.Promise" />
            var parameters = Array.prototype.slice.call(arguments, 0, 1);
            return lightSwitchApplication.showScreen("AddEditPhoneNumber", parameters, options);
        }),

        showAddEditAddress: $defineShowScreen(function showAddEditAddress(Address, options) {
            /// <summary>
            /// Asynchronously navigates forward to the AddEditAddress screen.
            /// </summary>
            /// <param name="options" optional="true">
            /// An object that provides one or more of the following options:<br/>- beforeShown: a function that is called after boundary behavior has been applied but before the screen is shown.<br/>+ Signature: beforeShown(screen)<br/>- afterClosed: a function that is called after boundary behavior has been applied and the screen has been closed.<br/>+ Signature: afterClosed(screen, action : msls.NavigateBackAction)
            /// </param>
            /// <returns type="WinJS.Promise" />
            var parameters = Array.prototype.slice.call(arguments, 0, 1);
            return lightSwitchApplication.showScreen("AddEditAddress", parameters, options);
        }),

        showBrowseContactsByPhone: $defineShowScreen(function showBrowseContactsByPhone(options) {
            /// <summary>
            /// Asynchronously navigates forward to the BrowseContactsByPhone screen.
            /// </summary>
            /// <param name="options" optional="true">
            /// An object that provides one or more of the following options:<br/>- beforeShown: a function that is called after boundary behavior has been applied but before the screen is shown.<br/>+ Signature: beforeShown(screen)<br/>- afterClosed: a function that is called after boundary behavior has been applied and the screen has been closed.<br/>+ Signature: afterClosed(screen, action : msls.NavigateBackAction)
            /// </param>
            /// <returns type="WinJS.Promise" />
            var parameters = Array.prototype.slice.call(arguments, 0, 0);
            return lightSwitchApplication.showScreen("BrowseContactsByPhone", parameters, options);
        })

    });

}(msls.application));
