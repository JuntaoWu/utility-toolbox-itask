window.AffairViewModel = window.AffairViewModel || function (app, dataModel) {
    var self = this;

    self.ID = '';
    self.Title = ko.observable('');
    self.Description = ko.observable('');
    self.ExpectedTime = ko.observable('');

    self.AffairList = ko.observableArray();

    self.ExpectedTimeDisplayed = ko.computed({
        read: function () {
            var dateTimeDisplayed = '';
            if (self.ExpectedTime()) {
                var dateTimeISOString = self.ExpectedTime();
                try {
                    var dateTime = new Date(dateTimeISOString);
                    dateTimeDisplayed = $.datepicker.formatDate('mm/dd/yy', dateTime);
                }
                catch (ex) {
                    console.error(ex.message, dateTimeISOString, dateTime);
                }
            }
            return dateTimeDisplayed;
        },
        write: function () {
            self.ExpectedTime($('#datepicker1').datepicker('getDate').toISOString());
        }
    });

    $('#datepicker1').datepicker();

    Sammy(function () {
        this.get('#affair/:affairId', function () {
            var affairId = this.params['affairId'];
            if (!affairId) {
                return;
            }
            self.sync(affairId);
        });
        this.get('#createAffair', function () {
            self.refresh();
            app.view(self.Views.Affair);
        });
    });

    return self;
};

window.AffairViewModel.prototype = {
    sync: function(targetId) {
        // Make a call to the protected Web API by passing in a Bearer Authorization Header
        var self = this;
        $.ajax({
            method: 'get',
            url: app.dataModel.getAffairUrl + "/" + targetId,
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                self.refresh(data);
                app.view(app.Views.Affair);
            }
        });

        $.ajax({
            method: 'get',
            url: app.dataModel.getAffairListUrl,
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if (data instanceof Array) {
                    self.AffairList(ko.utils.arrayMap(data, function (affair) {
                        return new AffairSummary(affair);
                    }));
                }
            }
        });
    },
    refresh: function (model) {
        console.log('Begin refresh app.affair');
        model = model || {};
        model.ID = model.ID || '';
        model.Title = model.Title || '';
        model.Description = model.Description || '';
        model.ExpectedTime = model.ExpectedTime || '';

        this.ID = model.ID;
        this.Title(model.Title);
        this.Description(model.Description);
        this.ExpectedTime(model.ExpectedTime);
        console.log('End refresh app.affair');
    },
    submitAffair: function () {
        var self = this;
        $.ajax({
            url: '/api/AffairService',
            method: 'POST',
            contentType: 'application/json; charset=utf-8',
            data: ko.toJSON(this),
            success: function (data) {
                console.log(data);
                self.refresh(data);
                app.navigateToAffair(self.ID);
            }
        });
    }
};

window.AffairSummary = window.AffairSummary || function (affair) {
    affair = affair || {};
    affair.Title = affair.Title || "";
    affair.ID = affair.ID || "";

    this.Title = ko.observable(affair.Title);
    this.ID = affair.ID;

    var self = this;
    this.ComputedHref = ko.computed(function () {
        return "#affair/" + self.ID;
    });
};

app.addViewModel({
    name: "Affair",
    bindingMemberName: "affair",
    factory: AffairViewModel,
    navigatorFactory: function (app, dataModel) {
        return function (affairId) {
            if ("#affair/" + affairId == window.location.hash) {
                app.affair().sync(affairId);
            }
            if (affairId) {
                window.location.hash = "#affair/" + affairId;
            }
            else {
                window.location.hash = "#createAffair";
            }
        }
    }
});