/// <reference path="viewModel.js" />

(function (lightSwitchApplication) {

    var $element = document.createElement("div");

    lightSwitchApplication.BrowseContacts.prototype._$contentItems = {
        Tabs: {
            _$class: msls.ContentItem,
            _$name: "Tabs",
            _$parentName: "RootContentItem",
            screen: lightSwitchApplication.BrowseContacts
        },
        ContactList: {
            _$class: msls.ContentItem,
            _$name: "ContactList",
            _$parentName: "Tabs",
            screen: lightSwitchApplication.BrowseContacts,
            data: lightSwitchApplication.BrowseContacts,
            value: lightSwitchApplication.BrowseContacts
        },
        FindContact: {
            _$class: msls.ContentItem,
            _$name: "FindContact",
            _$parentName: "ContactList",
            screen: lightSwitchApplication.BrowseContacts,
            data: lightSwitchApplication.BrowseContacts,
            value: String
        },
        Contacts: {
            _$class: msls.ContentItem,
            _$name: "Contacts",
            _$parentName: "ContactList",
            screen: lightSwitchApplication.BrowseContacts,
            data: lightSwitchApplication.BrowseContacts,
            value: {
                _$class: msls.VisualCollection,
                screen: lightSwitchApplication.BrowseContacts,
                _$entry: {
                    elementType: lightSwitchApplication.Contact
                }
            }
        },
        Contact: {
            _$class: msls.ContentItem,
            _$name: "Contact",
            _$parentName: "Contacts",
            screen: lightSwitchApplication.BrowseContacts,
            data: lightSwitchApplication.Contact,
            value: lightSwitchApplication.Contact
        },
        LastName: {
            _$class: msls.ContentItem,
            _$name: "LastName",
            _$parentName: "Contact",
            screen: lightSwitchApplication.BrowseContacts,
            data: lightSwitchApplication.Contact,
            value: String
        },
        FirstName: {
            _$class: msls.ContentItem,
            _$name: "FirstName",
            _$parentName: "Contact",
            screen: lightSwitchApplication.BrowseContacts,
            data: lightSwitchApplication.Contact,
            value: String
        },
        Contacts1: {
            _$class: msls.ContentItem,
            _$name: "Contacts1",
            _$parentName: "ContactList",
            screen: lightSwitchApplication.BrowseContacts,
            data: lightSwitchApplication.BrowseContacts,
            value: {
                _$class: msls.VisualCollection,
                screen: lightSwitchApplication.BrowseContacts,
                _$entry: {
                    elementType: lightSwitchApplication.Contact
                }
            }
        },
        Contacts1Template: {
            _$class: msls.ContentItem,
            _$name: "Contacts1Template",
            _$parentName: "Contacts1",
            screen: lightSwitchApplication.BrowseContacts,
            data: lightSwitchApplication.Contact,
            value: lightSwitchApplication.Contact
        },
        LastName1: {
            _$class: msls.ContentItem,
            _$name: "LastName1",
            _$parentName: "Contacts1Template",
            screen: lightSwitchApplication.BrowseContacts,
            data: lightSwitchApplication.Contact,
            value: String
        },
        FirstName1: {
            _$class: msls.ContentItem,
            _$name: "FirstName1",
            _$parentName: "Contacts1Template",
            screen: lightSwitchApplication.BrowseContacts,
            data: lightSwitchApplication.Contact,
            value: String
        },
        BirthDate: {
            _$class: msls.ContentItem,
            _$name: "BirthDate",
            _$parentName: "Contacts1Template",
            screen: lightSwitchApplication.BrowseContacts,
            data: lightSwitchApplication.Contact,
            value: Date
        },
        Gender: {
            _$class: msls.ContentItem,
            _$name: "Gender",
            _$parentName: "Contacts1Template",
            screen: lightSwitchApplication.BrowseContacts,
            data: lightSwitchApplication.Contact,
            value: String
        },
        CreatedBy: {
            _$class: msls.ContentItem,
            _$name: "CreatedBy",
            _$parentName: "Contacts1Template",
            screen: lightSwitchApplication.BrowseContacts,
            data: lightSwitchApplication.Contact,
            value: String
        },
        Created: {
            _$class: msls.ContentItem,
            _$name: "Created",
            _$parentName: "Contacts1Template",
            screen: lightSwitchApplication.BrowseContacts,
            data: lightSwitchApplication.Contact,
            value: Date
        },
        ModifiedBy: {
            _$class: msls.ContentItem,
            _$name: "ModifiedBy",
            _$parentName: "Contacts1Template",
            screen: lightSwitchApplication.BrowseContacts,
            data: lightSwitchApplication.Contact,
            value: String
        },
        Modified: {
            _$class: msls.ContentItem,
            _$name: "Modified",
            _$parentName: "Contacts1Template",
            screen: lightSwitchApplication.BrowseContacts,
            data: lightSwitchApplication.Contact,
            value: Date
        },
        Popups: {
            _$class: msls.ContentItem,
            _$name: "Popups",
            _$parentName: "RootContentItem",
            screen: lightSwitchApplication.BrowseContacts
        },
        Filter: {
            _$class: msls.ContentItem,
            _$name: "Filter",
            _$parentName: "Popups",
            screen: lightSwitchApplication.BrowseContacts,
            data: lightSwitchApplication.BrowseContacts,
            value: lightSwitchApplication.BrowseContacts
        },
        ContactMinimumBirthDate: {
            _$class: msls.ContentItem,
            _$name: "ContactMinimumBirthDate",
            _$parentName: "Filter",
            screen: lightSwitchApplication.BrowseContacts,
            data: lightSwitchApplication.BrowseContacts,
            value: Date
        },
        ContactMaximumBirthDate: {
            _$class: msls.ContentItem,
            _$name: "ContactMaximumBirthDate",
            _$parentName: "Filter",
            screen: lightSwitchApplication.BrowseContacts,
            data: lightSwitchApplication.BrowseContacts,
            value: Date
        }
    };

    msls._addEntryPoints(lightSwitchApplication.BrowseContacts, {
        /// <field>
        /// Called when a new BrowseContacts screen is created.
        /// <br/>created(msls.application.BrowseContacts screen)
        /// </field>
        created: [lightSwitchApplication.BrowseContacts],
        /// <field>
        /// Called before changes on an active BrowseContacts screen are applied.
        /// <br/>beforeApplyChanges(msls.application.BrowseContacts screen)
        /// </field>
        beforeApplyChanges: [lightSwitchApplication.BrowseContacts],
        /// <field>
        /// Called to determine if the AddContact_Tap method can be executed.
        /// <br/>canExecute(msls.application.BrowseContacts screen)
        /// </field>
        AddContact_Tap_canExecute: [lightSwitchApplication.BrowseContacts],
        /// <field>
        /// Called to execute the AddContact_Tap method.
        /// <br/>execute(msls.application.BrowseContacts screen)
        /// </field>
        AddContact_Tap_execute: [lightSwitchApplication.BrowseContacts],
        /// <field>
        /// Called after the ContactList content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        ContactList_postRender: [$element, function () { return new lightSwitchApplication.BrowseContacts().findContentItem("ContactList"); }],
        /// <field>
        /// Called after the FindContact content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        FindContact_postRender: [$element, function () { return new lightSwitchApplication.BrowseContacts().findContentItem("FindContact"); }],
        /// <field>
        /// Called after the Contacts content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        Contacts_postRender: [$element, function () { return new lightSwitchApplication.BrowseContacts().findContentItem("Contacts"); }],
        /// <field>
        /// Called after the Contact content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        Contact_postRender: [$element, function () { return new lightSwitchApplication.BrowseContacts().findContentItem("Contact"); }],
        /// <field>
        /// Called after the LastName content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        LastName_postRender: [$element, function () { return new lightSwitchApplication.BrowseContacts().findContentItem("LastName"); }],
        /// <field>
        /// Called after the FirstName content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        FirstName_postRender: [$element, function () { return new lightSwitchApplication.BrowseContacts().findContentItem("FirstName"); }],
        /// <field>
        /// Called to render the Contacts1 content item.
        /// <br/>render(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        Contacts1_render: [$element, function () { return new lightSwitchApplication.BrowseContacts().findContentItem("Contacts1"); }],
        /// <field>
        /// Called after the Contacts1Template content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        Contacts1Template_postRender: [$element, function () { return new lightSwitchApplication.BrowseContacts().findContentItem("Contacts1Template"); }],
        /// <field>
        /// Called after the LastName1 content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        LastName1_postRender: [$element, function () { return new lightSwitchApplication.BrowseContacts().findContentItem("LastName1"); }],
        /// <field>
        /// Called after the FirstName1 content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        FirstName1_postRender: [$element, function () { return new lightSwitchApplication.BrowseContacts().findContentItem("FirstName1"); }],
        /// <field>
        /// Called after the BirthDate content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        BirthDate_postRender: [$element, function () { return new lightSwitchApplication.BrowseContacts().findContentItem("BirthDate"); }],
        /// <field>
        /// Called after the Gender content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        Gender_postRender: [$element, function () { return new lightSwitchApplication.BrowseContacts().findContentItem("Gender"); }],
        /// <field>
        /// Called after the CreatedBy content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        CreatedBy_postRender: [$element, function () { return new lightSwitchApplication.BrowseContacts().findContentItem("CreatedBy"); }],
        /// <field>
        /// Called after the Created content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        Created_postRender: [$element, function () { return new lightSwitchApplication.BrowseContacts().findContentItem("Created"); }],
        /// <field>
        /// Called after the ModifiedBy content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        ModifiedBy_postRender: [$element, function () { return new lightSwitchApplication.BrowseContacts().findContentItem("ModifiedBy"); }],
        /// <field>
        /// Called after the Modified content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        Modified_postRender: [$element, function () { return new lightSwitchApplication.BrowseContacts().findContentItem("Modified"); }],
        /// <field>
        /// Called after the Filter content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        Filter_postRender: [$element, function () { return new lightSwitchApplication.BrowseContacts().findContentItem("Filter"); }],
        /// <field>
        /// Called after the ContactMinimumBirthDate content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        ContactMinimumBirthDate_postRender: [$element, function () { return new lightSwitchApplication.BrowseContacts().findContentItem("ContactMinimumBirthDate"); }],
        /// <field>
        /// Called after the ContactMaximumBirthDate content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        ContactMaximumBirthDate_postRender: [$element, function () { return new lightSwitchApplication.BrowseContacts().findContentItem("ContactMaximumBirthDate"); }]
    });

    lightSwitchApplication.AddEditContact.prototype._$contentItems = {
        Tabs: {
            _$class: msls.ContentItem,
            _$name: "Tabs",
            _$parentName: "RootContentItem",
            screen: lightSwitchApplication.AddEditContact
        },
        Details: {
            _$class: msls.ContentItem,
            _$name: "Details",
            _$parentName: "Tabs",
            screen: lightSwitchApplication.AddEditContact,
            data: lightSwitchApplication.AddEditContact,
            value: lightSwitchApplication.AddEditContact
        },
        columns: {
            _$class: msls.ContentItem,
            _$name: "columns",
            _$parentName: "Details",
            screen: lightSwitchApplication.AddEditContact,
            data: lightSwitchApplication.AddEditContact,
            value: lightSwitchApplication.Contact
        },
        left: {
            _$class: msls.ContentItem,
            _$name: "left",
            _$parentName: "columns",
            screen: lightSwitchApplication.AddEditContact,
            data: lightSwitchApplication.Contact,
            value: lightSwitchApplication.Contact
        },
        LastName: {
            _$class: msls.ContentItem,
            _$name: "LastName",
            _$parentName: "left",
            screen: lightSwitchApplication.AddEditContact,
            data: lightSwitchApplication.Contact,
            value: String
        },
        FirstName: {
            _$class: msls.ContentItem,
            _$name: "FirstName",
            _$parentName: "left",
            screen: lightSwitchApplication.AddEditContact,
            data: lightSwitchApplication.Contact,
            value: String
        },
        right: {
            _$class: msls.ContentItem,
            _$name: "right",
            _$parentName: "columns",
            screen: lightSwitchApplication.AddEditContact,
            data: lightSwitchApplication.Contact,
            value: lightSwitchApplication.Contact
        },
        BirthDate: {
            _$class: msls.ContentItem,
            _$name: "BirthDate",
            _$parentName: "right",
            screen: lightSwitchApplication.AddEditContact,
            data: lightSwitchApplication.Contact,
            value: Date
        },
        Gender: {
            _$class: msls.ContentItem,
            _$name: "Gender",
            _$parentName: "right",
            screen: lightSwitchApplication.AddEditContact,
            data: lightSwitchApplication.Contact,
            value: String
        },
        Popups: {
            _$class: msls.ContentItem,
            _$name: "Popups",
            _$parentName: "RootContentItem",
            screen: lightSwitchApplication.AddEditContact
        }
    };

    msls._addEntryPoints(lightSwitchApplication.AddEditContact, {
        /// <field>
        /// Called when a new AddEditContact screen is created.
        /// <br/>created(msls.application.AddEditContact screen)
        /// </field>
        created: [lightSwitchApplication.AddEditContact],
        /// <field>
        /// Called before changes on an active AddEditContact screen are applied.
        /// <br/>beforeApplyChanges(msls.application.AddEditContact screen)
        /// </field>
        beforeApplyChanges: [lightSwitchApplication.AddEditContact],
        /// <field>
        /// Called after the Details content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        Details_postRender: [$element, function () { return new lightSwitchApplication.AddEditContact().findContentItem("Details"); }],
        /// <field>
        /// Called after the columns content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        columns_postRender: [$element, function () { return new lightSwitchApplication.AddEditContact().findContentItem("columns"); }],
        /// <field>
        /// Called after the left content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        left_postRender: [$element, function () { return new lightSwitchApplication.AddEditContact().findContentItem("left"); }],
        /// <field>
        /// Called after the LastName content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        LastName_postRender: [$element, function () { return new lightSwitchApplication.AddEditContact().findContentItem("LastName"); }],
        /// <field>
        /// Called after the FirstName content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        FirstName_postRender: [$element, function () { return new lightSwitchApplication.AddEditContact().findContentItem("FirstName"); }],
        /// <field>
        /// Called after the right content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        right_postRender: [$element, function () { return new lightSwitchApplication.AddEditContact().findContentItem("right"); }],
        /// <field>
        /// Called after the BirthDate content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        BirthDate_postRender: [$element, function () { return new lightSwitchApplication.AddEditContact().findContentItem("BirthDate"); }],
        /// <field>
        /// Called after the Gender content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        Gender_postRender: [$element, function () { return new lightSwitchApplication.AddEditContact().findContentItem("Gender"); }]
    });

    lightSwitchApplication.ViewContact.prototype._$contentItems = {
        Tabs: {
            _$class: msls.ContentItem,
            _$name: "Tabs",
            _$parentName: "RootContentItem",
            screen: lightSwitchApplication.ViewContact
        },
        Details: {
            _$class: msls.ContentItem,
            _$name: "Details",
            _$parentName: "Tabs",
            screen: lightSwitchApplication.ViewContact,
            data: lightSwitchApplication.ViewContact,
            value: lightSwitchApplication.ViewContact
        },
        columns: {
            _$class: msls.ContentItem,
            _$name: "columns",
            _$parentName: "Details",
            screen: lightSwitchApplication.ViewContact,
            data: lightSwitchApplication.ViewContact,
            value: lightSwitchApplication.Contact
        },
        left: {
            _$class: msls.ContentItem,
            _$name: "left",
            _$parentName: "columns",
            screen: lightSwitchApplication.ViewContact,
            data: lightSwitchApplication.Contact,
            value: lightSwitchApplication.Contact
        },
        LastName: {
            _$class: msls.ContentItem,
            _$name: "LastName",
            _$parentName: "left",
            screen: lightSwitchApplication.ViewContact,
            data: lightSwitchApplication.Contact,
            value: String
        },
        FirstName: {
            _$class: msls.ContentItem,
            _$name: "FirstName",
            _$parentName: "left",
            screen: lightSwitchApplication.ViewContact,
            data: lightSwitchApplication.Contact,
            value: String
        },
        BirthDate: {
            _$class: msls.ContentItem,
            _$name: "BirthDate",
            _$parentName: "left",
            screen: lightSwitchApplication.ViewContact,
            data: lightSwitchApplication.Contact,
            value: Date
        },
        Gender: {
            _$class: msls.ContentItem,
            _$name: "Gender",
            _$parentName: "left",
            screen: lightSwitchApplication.ViewContact,
            data: lightSwitchApplication.Contact,
            value: String
        },
        EmailAddresses1: {
            _$class: msls.ContentItem,
            _$name: "EmailAddresses1",
            _$parentName: "left",
            screen: lightSwitchApplication.ViewContact,
            data: lightSwitchApplication.Contact,
            value: {
                _$class: msls.VisualCollection,
                screen: lightSwitchApplication.ViewContact,
                _$entry: {
                    elementType: lightSwitchApplication.EmailAddress
                }
            }
        },
        rows: {
            _$class: msls.ContentItem,
            _$name: "rows",
            _$parentName: "EmailAddresses1",
            screen: lightSwitchApplication.ViewContact,
            data: lightSwitchApplication.EmailAddress,
            value: lightSwitchApplication.EmailAddress
        },
        Email: {
            _$class: msls.ContentItem,
            _$name: "Email",
            _$parentName: "rows",
            screen: lightSwitchApplication.ViewContact,
            data: lightSwitchApplication.EmailAddress,
            value: String
        },
        EmailType: {
            _$class: msls.ContentItem,
            _$name: "EmailType",
            _$parentName: "rows",
            screen: lightSwitchApplication.ViewContact,
            data: lightSwitchApplication.EmailAddress,
            value: String
        },
        PhoneNumbers1: {
            _$class: msls.ContentItem,
            _$name: "PhoneNumbers1",
            _$parentName: "left",
            screen: lightSwitchApplication.ViewContact,
            data: lightSwitchApplication.Contact,
            value: {
                _$class: msls.VisualCollection,
                screen: lightSwitchApplication.ViewContact,
                _$entry: {
                    elementType: lightSwitchApplication.PhoneNumber
                }
            }
        },
        rows1: {
            _$class: msls.ContentItem,
            _$name: "rows1",
            _$parentName: "PhoneNumbers1",
            screen: lightSwitchApplication.ViewContact,
            data: lightSwitchApplication.PhoneNumber,
            value: lightSwitchApplication.PhoneNumber
        },
        Phone: {
            _$class: msls.ContentItem,
            _$name: "Phone",
            _$parentName: "rows1",
            screen: lightSwitchApplication.ViewContact,
            data: lightSwitchApplication.PhoneNumber,
            value: String
        },
        PhoneType: {
            _$class: msls.ContentItem,
            _$name: "PhoneType",
            _$parentName: "rows1",
            screen: lightSwitchApplication.ViewContact,
            data: lightSwitchApplication.PhoneNumber,
            value: String
        },
        Addresses1: {
            _$class: msls.ContentItem,
            _$name: "Addresses1",
            _$parentName: "left",
            screen: lightSwitchApplication.ViewContact,
            data: lightSwitchApplication.Contact,
            value: {
                _$class: msls.VisualCollection,
                screen: lightSwitchApplication.ViewContact,
                _$entry: {
                    elementType: lightSwitchApplication.Address
                }
            }
        },
        Address: {
            _$class: msls.ContentItem,
            _$name: "Address",
            _$parentName: "Addresses1",
            screen: lightSwitchApplication.ViewContact,
            data: lightSwitchApplication.Address,
            value: lightSwitchApplication.Address
        },
        AddressType: {
            _$class: msls.ContentItem,
            _$name: "AddressType",
            _$parentName: "Address",
            screen: lightSwitchApplication.ViewContact,
            data: lightSwitchApplication.Address,
            value: String
        },
        Address1: {
            _$class: msls.ContentItem,
            _$name: "Address1",
            _$parentName: "Address",
            screen: lightSwitchApplication.ViewContact,
            data: lightSwitchApplication.Address,
            value: String
        },
        Address2: {
            _$class: msls.ContentItem,
            _$name: "Address2",
            _$parentName: "Address",
            screen: lightSwitchApplication.ViewContact,
            data: lightSwitchApplication.Address,
            value: String
        },
        Group: {
            _$class: msls.ContentItem,
            _$name: "Group",
            _$parentName: "Address",
            screen: lightSwitchApplication.ViewContact,
            data: lightSwitchApplication.Address,
            value: lightSwitchApplication.Address
        },
        City: {
            _$class: msls.ContentItem,
            _$name: "City",
            _$parentName: "Group",
            screen: lightSwitchApplication.ViewContact,
            data: lightSwitchApplication.Address,
            value: String
        },
        State: {
            _$class: msls.ContentItem,
            _$name: "State",
            _$parentName: "Group",
            screen: lightSwitchApplication.ViewContact,
            data: lightSwitchApplication.Address,
            value: String
        },
        ZIP: {
            _$class: msls.ContentItem,
            _$name: "ZIP",
            _$parentName: "Group",
            screen: lightSwitchApplication.ViewContact,
            data: lightSwitchApplication.Address,
            value: String
        },
        right: {
            _$class: msls.ContentItem,
            _$name: "right",
            _$parentName: "columns",
            screen: lightSwitchApplication.ViewContact,
            data: lightSwitchApplication.Contact,
            value: lightSwitchApplication.Contact
        },
        CreatedBy: {
            _$class: msls.ContentItem,
            _$name: "CreatedBy",
            _$parentName: "right",
            screen: lightSwitchApplication.ViewContact,
            data: lightSwitchApplication.Contact,
            value: String
        },
        Created: {
            _$class: msls.ContentItem,
            _$name: "Created",
            _$parentName: "right",
            screen: lightSwitchApplication.ViewContact,
            data: lightSwitchApplication.Contact,
            value: Date
        },
        ModifiedBy: {
            _$class: msls.ContentItem,
            _$name: "ModifiedBy",
            _$parentName: "right",
            screen: lightSwitchApplication.ViewContact,
            data: lightSwitchApplication.Contact,
            value: String
        },
        Modified: {
            _$class: msls.ContentItem,
            _$name: "Modified",
            _$parentName: "right",
            screen: lightSwitchApplication.ViewContact,
            data: lightSwitchApplication.Contact,
            value: Date
        },
        Popups: {
            _$class: msls.ContentItem,
            _$name: "Popups",
            _$parentName: "RootContentItem",
            screen: lightSwitchApplication.ViewContact
        }
    };

    msls._addEntryPoints(lightSwitchApplication.ViewContact, {
        /// <field>
        /// Called when a new ViewContact screen is created.
        /// <br/>created(msls.application.ViewContact screen)
        /// </field>
        created: [lightSwitchApplication.ViewContact],
        /// <field>
        /// Called before changes on an active ViewContact screen are applied.
        /// <br/>beforeApplyChanges(msls.application.ViewContact screen)
        /// </field>
        beforeApplyChanges: [lightSwitchApplication.ViewContact],
        /// <field>
        /// Called after the Details content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        Details_postRender: [$element, function () { return new lightSwitchApplication.ViewContact().findContentItem("Details"); }],
        /// <field>
        /// Called after the columns content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        columns_postRender: [$element, function () { return new lightSwitchApplication.ViewContact().findContentItem("columns"); }],
        /// <field>
        /// Called after the left content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        left_postRender: [$element, function () { return new lightSwitchApplication.ViewContact().findContentItem("left"); }],
        /// <field>
        /// Called after the LastName content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        LastName_postRender: [$element, function () { return new lightSwitchApplication.ViewContact().findContentItem("LastName"); }],
        /// <field>
        /// Called after the FirstName content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        FirstName_postRender: [$element, function () { return new lightSwitchApplication.ViewContact().findContentItem("FirstName"); }],
        /// <field>
        /// Called after the BirthDate content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        BirthDate_postRender: [$element, function () { return new lightSwitchApplication.ViewContact().findContentItem("BirthDate"); }],
        /// <field>
        /// Called after the Gender content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        Gender_postRender: [$element, function () { return new lightSwitchApplication.ViewContact().findContentItem("Gender"); }],
        /// <field>
        /// Called after the EmailAddresses1 content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        EmailAddresses1_postRender: [$element, function () { return new lightSwitchApplication.ViewContact().findContentItem("EmailAddresses1"); }],
        /// <field>
        /// Called after the rows content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        rows_postRender: [$element, function () { return new lightSwitchApplication.ViewContact().findContentItem("rows"); }],
        /// <field>
        /// Called after the Email content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        Email_postRender: [$element, function () { return new lightSwitchApplication.ViewContact().findContentItem("Email"); }],
        /// <field>
        /// Called after the EmailType content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        EmailType_postRender: [$element, function () { return new lightSwitchApplication.ViewContact().findContentItem("EmailType"); }],
        /// <field>
        /// Called after the PhoneNumbers1 content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        PhoneNumbers1_postRender: [$element, function () { return new lightSwitchApplication.ViewContact().findContentItem("PhoneNumbers1"); }],
        /// <field>
        /// Called after the rows1 content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        rows1_postRender: [$element, function () { return new lightSwitchApplication.ViewContact().findContentItem("rows1"); }],
        /// <field>
        /// Called after the Phone content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        Phone_postRender: [$element, function () { return new lightSwitchApplication.ViewContact().findContentItem("Phone"); }],
        /// <field>
        /// Called after the PhoneType content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        PhoneType_postRender: [$element, function () { return new lightSwitchApplication.ViewContact().findContentItem("PhoneType"); }],
        /// <field>
        /// Called after the Addresses1 content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        Addresses1_postRender: [$element, function () { return new lightSwitchApplication.ViewContact().findContentItem("Addresses1"); }],
        /// <field>
        /// Called after the Address content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        Address_postRender: [$element, function () { return new lightSwitchApplication.ViewContact().findContentItem("Address"); }],
        /// <field>
        /// Called after the AddressType content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        AddressType_postRender: [$element, function () { return new lightSwitchApplication.ViewContact().findContentItem("AddressType"); }],
        /// <field>
        /// Called after the Address1 content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        Address1_postRender: [$element, function () { return new lightSwitchApplication.ViewContact().findContentItem("Address1"); }],
        /// <field>
        /// Called after the Address2 content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        Address2_postRender: [$element, function () { return new lightSwitchApplication.ViewContact().findContentItem("Address2"); }],
        /// <field>
        /// Called after the Group content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        Group_postRender: [$element, function () { return new lightSwitchApplication.ViewContact().findContentItem("Group"); }],
        /// <field>
        /// Called after the City content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        City_postRender: [$element, function () { return new lightSwitchApplication.ViewContact().findContentItem("City"); }],
        /// <field>
        /// Called after the State content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        State_postRender: [$element, function () { return new lightSwitchApplication.ViewContact().findContentItem("State"); }],
        /// <field>
        /// Called after the ZIP content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        ZIP_postRender: [$element, function () { return new lightSwitchApplication.ViewContact().findContentItem("ZIP"); }],
        /// <field>
        /// Called after the right content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        right_postRender: [$element, function () { return new lightSwitchApplication.ViewContact().findContentItem("right"); }],
        /// <field>
        /// Called after the CreatedBy content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        CreatedBy_postRender: [$element, function () { return new lightSwitchApplication.ViewContact().findContentItem("CreatedBy"); }],
        /// <field>
        /// Called after the Created content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        Created_postRender: [$element, function () { return new lightSwitchApplication.ViewContact().findContentItem("Created"); }],
        /// <field>
        /// Called after the ModifiedBy content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        ModifiedBy_postRender: [$element, function () { return new lightSwitchApplication.ViewContact().findContentItem("ModifiedBy"); }],
        /// <field>
        /// Called after the Modified content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        Modified_postRender: [$element, function () { return new lightSwitchApplication.ViewContact().findContentItem("Modified"); }]
    });

    lightSwitchApplication.AddEditEmailAddress.prototype._$contentItems = {
        Tabs: {
            _$class: msls.ContentItem,
            _$name: "Tabs",
            _$parentName: "RootContentItem",
            screen: lightSwitchApplication.AddEditEmailAddress
        },
        Details: {
            _$class: msls.ContentItem,
            _$name: "Details",
            _$parentName: "Tabs",
            screen: lightSwitchApplication.AddEditEmailAddress,
            data: lightSwitchApplication.AddEditEmailAddress,
            value: lightSwitchApplication.AddEditEmailAddress
        },
        columns: {
            _$class: msls.ContentItem,
            _$name: "columns",
            _$parentName: "Details",
            screen: lightSwitchApplication.AddEditEmailAddress,
            data: lightSwitchApplication.AddEditEmailAddress,
            value: lightSwitchApplication.EmailAddress
        },
        left: {
            _$class: msls.ContentItem,
            _$name: "left",
            _$parentName: "columns",
            screen: lightSwitchApplication.AddEditEmailAddress,
            data: lightSwitchApplication.EmailAddress,
            value: lightSwitchApplication.EmailAddress
        },
        Email: {
            _$class: msls.ContentItem,
            _$name: "Email",
            _$parentName: "left",
            screen: lightSwitchApplication.AddEditEmailAddress,
            data: lightSwitchApplication.EmailAddress,
            value: String
        },
        EmailType: {
            _$class: msls.ContentItem,
            _$name: "EmailType",
            _$parentName: "left",
            screen: lightSwitchApplication.AddEditEmailAddress,
            data: lightSwitchApplication.EmailAddress,
            value: String
        },
        Popups: {
            _$class: msls.ContentItem,
            _$name: "Popups",
            _$parentName: "RootContentItem",
            screen: lightSwitchApplication.AddEditEmailAddress
        }
    };

    msls._addEntryPoints(lightSwitchApplication.AddEditEmailAddress, {
        /// <field>
        /// Called when a new AddEditEmailAddress screen is created.
        /// <br/>created(msls.application.AddEditEmailAddress screen)
        /// </field>
        created: [lightSwitchApplication.AddEditEmailAddress],
        /// <field>
        /// Called before changes on an active AddEditEmailAddress screen are applied.
        /// <br/>beforeApplyChanges(msls.application.AddEditEmailAddress screen)
        /// </field>
        beforeApplyChanges: [lightSwitchApplication.AddEditEmailAddress],
        /// <field>
        /// Called after the Details content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        Details_postRender: [$element, function () { return new lightSwitchApplication.AddEditEmailAddress().findContentItem("Details"); }],
        /// <field>
        /// Called after the columns content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        columns_postRender: [$element, function () { return new lightSwitchApplication.AddEditEmailAddress().findContentItem("columns"); }],
        /// <field>
        /// Called after the left content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        left_postRender: [$element, function () { return new lightSwitchApplication.AddEditEmailAddress().findContentItem("left"); }],
        /// <field>
        /// Called after the Email content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        Email_postRender: [$element, function () { return new lightSwitchApplication.AddEditEmailAddress().findContentItem("Email"); }],
        /// <field>
        /// Called after the EmailType content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        EmailType_postRender: [$element, function () { return new lightSwitchApplication.AddEditEmailAddress().findContentItem("EmailType"); }]
    });

    lightSwitchApplication.AddEditPhoneNumber.prototype._$contentItems = {
        Tabs: {
            _$class: msls.ContentItem,
            _$name: "Tabs",
            _$parentName: "RootContentItem",
            screen: lightSwitchApplication.AddEditPhoneNumber
        },
        Details: {
            _$class: msls.ContentItem,
            _$name: "Details",
            _$parentName: "Tabs",
            screen: lightSwitchApplication.AddEditPhoneNumber,
            data: lightSwitchApplication.AddEditPhoneNumber,
            value: lightSwitchApplication.AddEditPhoneNumber
        },
        columns: {
            _$class: msls.ContentItem,
            _$name: "columns",
            _$parentName: "Details",
            screen: lightSwitchApplication.AddEditPhoneNumber,
            data: lightSwitchApplication.AddEditPhoneNumber,
            value: lightSwitchApplication.PhoneNumber
        },
        left: {
            _$class: msls.ContentItem,
            _$name: "left",
            _$parentName: "columns",
            screen: lightSwitchApplication.AddEditPhoneNumber,
            data: lightSwitchApplication.PhoneNumber,
            value: lightSwitchApplication.PhoneNumber
        },
        Phone: {
            _$class: msls.ContentItem,
            _$name: "Phone",
            _$parentName: "left",
            screen: lightSwitchApplication.AddEditPhoneNumber,
            data: lightSwitchApplication.PhoneNumber,
            value: String
        },
        PhoneType: {
            _$class: msls.ContentItem,
            _$name: "PhoneType",
            _$parentName: "left",
            screen: lightSwitchApplication.AddEditPhoneNumber,
            data: lightSwitchApplication.PhoneNumber,
            value: String
        },
        Popups: {
            _$class: msls.ContentItem,
            _$name: "Popups",
            _$parentName: "RootContentItem",
            screen: lightSwitchApplication.AddEditPhoneNumber
        }
    };

    msls._addEntryPoints(lightSwitchApplication.AddEditPhoneNumber, {
        /// <field>
        /// Called when a new AddEditPhoneNumber screen is created.
        /// <br/>created(msls.application.AddEditPhoneNumber screen)
        /// </field>
        created: [lightSwitchApplication.AddEditPhoneNumber],
        /// <field>
        /// Called before changes on an active AddEditPhoneNumber screen are applied.
        /// <br/>beforeApplyChanges(msls.application.AddEditPhoneNumber screen)
        /// </field>
        beforeApplyChanges: [lightSwitchApplication.AddEditPhoneNumber],
        /// <field>
        /// Called after the Details content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        Details_postRender: [$element, function () { return new lightSwitchApplication.AddEditPhoneNumber().findContentItem("Details"); }],
        /// <field>
        /// Called after the columns content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        columns_postRender: [$element, function () { return new lightSwitchApplication.AddEditPhoneNumber().findContentItem("columns"); }],
        /// <field>
        /// Called after the left content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        left_postRender: [$element, function () { return new lightSwitchApplication.AddEditPhoneNumber().findContentItem("left"); }],
        /// <field>
        /// Called after the Phone content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        Phone_postRender: [$element, function () { return new lightSwitchApplication.AddEditPhoneNumber().findContentItem("Phone"); }],
        /// <field>
        /// Called after the PhoneType content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        PhoneType_postRender: [$element, function () { return new lightSwitchApplication.AddEditPhoneNumber().findContentItem("PhoneType"); }]
    });

    lightSwitchApplication.AddEditAddress.prototype._$contentItems = {
        Tabs: {
            _$class: msls.ContentItem,
            _$name: "Tabs",
            _$parentName: "RootContentItem",
            screen: lightSwitchApplication.AddEditAddress
        },
        Details: {
            _$class: msls.ContentItem,
            _$name: "Details",
            _$parentName: "Tabs",
            screen: lightSwitchApplication.AddEditAddress,
            data: lightSwitchApplication.AddEditAddress,
            value: lightSwitchApplication.AddEditAddress
        },
        columns: {
            _$class: msls.ContentItem,
            _$name: "columns",
            _$parentName: "Details",
            screen: lightSwitchApplication.AddEditAddress,
            data: lightSwitchApplication.AddEditAddress,
            value: lightSwitchApplication.Address
        },
        left: {
            _$class: msls.ContentItem,
            _$name: "left",
            _$parentName: "columns",
            screen: lightSwitchApplication.AddEditAddress,
            data: lightSwitchApplication.Address,
            value: lightSwitchApplication.Address
        },
        AddressType: {
            _$class: msls.ContentItem,
            _$name: "AddressType",
            _$parentName: "left",
            screen: lightSwitchApplication.AddEditAddress,
            data: lightSwitchApplication.Address,
            value: String
        },
        Address1: {
            _$class: msls.ContentItem,
            _$name: "Address1",
            _$parentName: "left",
            screen: lightSwitchApplication.AddEditAddress,
            data: lightSwitchApplication.Address,
            value: String
        },
        Address2: {
            _$class: msls.ContentItem,
            _$name: "Address2",
            _$parentName: "left",
            screen: lightSwitchApplication.AddEditAddress,
            data: lightSwitchApplication.Address,
            value: String
        },
        City: {
            _$class: msls.ContentItem,
            _$name: "City",
            _$parentName: "left",
            screen: lightSwitchApplication.AddEditAddress,
            data: lightSwitchApplication.Address,
            value: String
        },
        right: {
            _$class: msls.ContentItem,
            _$name: "right",
            _$parentName: "columns",
            screen: lightSwitchApplication.AddEditAddress,
            data: lightSwitchApplication.Address,
            value: lightSwitchApplication.Address
        },
        State: {
            _$class: msls.ContentItem,
            _$name: "State",
            _$parentName: "right",
            screen: lightSwitchApplication.AddEditAddress,
            data: lightSwitchApplication.Address,
            value: String
        },
        ZIP: {
            _$class: msls.ContentItem,
            _$name: "ZIP",
            _$parentName: "right",
            screen: lightSwitchApplication.AddEditAddress,
            data: lightSwitchApplication.Address,
            value: String
        },
        Popups: {
            _$class: msls.ContentItem,
            _$name: "Popups",
            _$parentName: "RootContentItem",
            screen: lightSwitchApplication.AddEditAddress
        }
    };

    msls._addEntryPoints(lightSwitchApplication.AddEditAddress, {
        /// <field>
        /// Called when a new AddEditAddress screen is created.
        /// <br/>created(msls.application.AddEditAddress screen)
        /// </field>
        created: [lightSwitchApplication.AddEditAddress],
        /// <field>
        /// Called before changes on an active AddEditAddress screen are applied.
        /// <br/>beforeApplyChanges(msls.application.AddEditAddress screen)
        /// </field>
        beforeApplyChanges: [lightSwitchApplication.AddEditAddress],
        /// <field>
        /// Called after the Details content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        Details_postRender: [$element, function () { return new lightSwitchApplication.AddEditAddress().findContentItem("Details"); }],
        /// <field>
        /// Called after the columns content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        columns_postRender: [$element, function () { return new lightSwitchApplication.AddEditAddress().findContentItem("columns"); }],
        /// <field>
        /// Called after the left content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        left_postRender: [$element, function () { return new lightSwitchApplication.AddEditAddress().findContentItem("left"); }],
        /// <field>
        /// Called after the AddressType content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        AddressType_postRender: [$element, function () { return new lightSwitchApplication.AddEditAddress().findContentItem("AddressType"); }],
        /// <field>
        /// Called after the Address1 content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        Address1_postRender: [$element, function () { return new lightSwitchApplication.AddEditAddress().findContentItem("Address1"); }],
        /// <field>
        /// Called after the Address2 content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        Address2_postRender: [$element, function () { return new lightSwitchApplication.AddEditAddress().findContentItem("Address2"); }],
        /// <field>
        /// Called after the City content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        City_postRender: [$element, function () { return new lightSwitchApplication.AddEditAddress().findContentItem("City"); }],
        /// <field>
        /// Called after the right content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        right_postRender: [$element, function () { return new lightSwitchApplication.AddEditAddress().findContentItem("right"); }],
        /// <field>
        /// Called after the State content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        State_postRender: [$element, function () { return new lightSwitchApplication.AddEditAddress().findContentItem("State"); }],
        /// <field>
        /// Called after the ZIP content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        ZIP_postRender: [$element, function () { return new lightSwitchApplication.AddEditAddress().findContentItem("ZIP"); }]
    });

    lightSwitchApplication.BrowseContactsByPhone.prototype._$contentItems = {
        Tabs: {
            _$class: msls.ContentItem,
            _$name: "Tabs",
            _$parentName: "RootContentItem",
            screen: lightSwitchApplication.BrowseContactsByPhone
        },
        PhoneNumberList: {
            _$class: msls.ContentItem,
            _$name: "PhoneNumberList",
            _$parentName: "Tabs",
            screen: lightSwitchApplication.BrowseContactsByPhone,
            data: lightSwitchApplication.BrowseContactsByPhone,
            value: lightSwitchApplication.BrowseContactsByPhone
        },
        PhoneNumberFindContact: {
            _$class: msls.ContentItem,
            _$name: "PhoneNumberFindContact",
            _$parentName: "PhoneNumberList",
            screen: lightSwitchApplication.BrowseContactsByPhone,
            data: lightSwitchApplication.BrowseContactsByPhone,
            value: String
        },
        ContactsByPhone: {
            _$class: msls.ContentItem,
            _$name: "ContactsByPhone",
            _$parentName: "PhoneNumberList",
            screen: lightSwitchApplication.BrowseContactsByPhone,
            data: lightSwitchApplication.BrowseContactsByPhone,
            value: {
                _$class: msls.VisualCollection,
                screen: lightSwitchApplication.BrowseContactsByPhone,
                _$entry: {
                    elementType: lightSwitchApplication.PhoneNumber
                }
            }
        },
        rows: {
            _$class: msls.ContentItem,
            _$name: "rows",
            _$parentName: "ContactsByPhone",
            screen: lightSwitchApplication.BrowseContactsByPhone,
            data: lightSwitchApplication.PhoneNumber,
            value: lightSwitchApplication.PhoneNumber
        },
        Phone: {
            _$class: msls.ContentItem,
            _$name: "Phone",
            _$parentName: "rows",
            screen: lightSwitchApplication.BrowseContactsByPhone,
            data: lightSwitchApplication.PhoneNumber,
            value: String
        },
        PhoneType: {
            _$class: msls.ContentItem,
            _$name: "PhoneType",
            _$parentName: "rows",
            screen: lightSwitchApplication.BrowseContactsByPhone,
            data: lightSwitchApplication.PhoneNumber,
            value: String
        },
        Contact: {
            _$class: msls.ContentItem,
            _$name: "Contact",
            _$parentName: "rows",
            screen: lightSwitchApplication.BrowseContactsByPhone,
            data: lightSwitchApplication.PhoneNumber,
            value: lightSwitchApplication.Contact
        },
        Popups: {
            _$class: msls.ContentItem,
            _$name: "Popups",
            _$parentName: "RootContentItem",
            screen: lightSwitchApplication.BrowseContactsByPhone
        }
    };

    msls._addEntryPoints(lightSwitchApplication.BrowseContactsByPhone, {
        /// <field>
        /// Called when a new BrowseContactsByPhone screen is created.
        /// <br/>created(msls.application.BrowseContactsByPhone screen)
        /// </field>
        created: [lightSwitchApplication.BrowseContactsByPhone],
        /// <field>
        /// Called before changes on an active BrowseContactsByPhone screen are applied.
        /// <br/>beforeApplyChanges(msls.application.BrowseContactsByPhone screen)
        /// </field>
        beforeApplyChanges: [lightSwitchApplication.BrowseContactsByPhone],
        /// <field>
        /// Called after the PhoneNumberList content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        PhoneNumberList_postRender: [$element, function () { return new lightSwitchApplication.BrowseContactsByPhone().findContentItem("PhoneNumberList"); }],
        /// <field>
        /// Called after the PhoneNumberFindContact content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        PhoneNumberFindContact_postRender: [$element, function () { return new lightSwitchApplication.BrowseContactsByPhone().findContentItem("PhoneNumberFindContact"); }],
        /// <field>
        /// Called after the ContactsByPhone content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        ContactsByPhone_postRender: [$element, function () { return new lightSwitchApplication.BrowseContactsByPhone().findContentItem("ContactsByPhone"); }],
        /// <field>
        /// Called after the rows content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        rows_postRender: [$element, function () { return new lightSwitchApplication.BrowseContactsByPhone().findContentItem("rows"); }],
        /// <field>
        /// Called after the Phone content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        Phone_postRender: [$element, function () { return new lightSwitchApplication.BrowseContactsByPhone().findContentItem("Phone"); }],
        /// <field>
        /// Called after the PhoneType content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        PhoneType_postRender: [$element, function () { return new lightSwitchApplication.BrowseContactsByPhone().findContentItem("PhoneType"); }],
        /// <field>
        /// Called after the Contact content item has been rendered.
        /// <br/>postRender(HTMLElement element, msls.ContentItem contentItem)
        /// </field>
        Contact_postRender: [$element, function () { return new lightSwitchApplication.BrowseContactsByPhone().findContentItem("Contact"); }]
    });

}(msls.application));