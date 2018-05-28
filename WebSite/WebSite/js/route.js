var app = angular.module("MyTestSafeweb", ["ngRoute"]);
app.config(function ($routeProvider) {
    $routeProvider
        .when("/", {
            templateUrl: "../login.html",
            controller: "UserController"
        })
        .when("/main", {
            templateUrl: "../views/main.html"
        })
        .when("/user", {
            templateUrl: "../views/user/user.html",
            controller: "UserController"
        })
        .when("/user/list", {
            templateUrl: "../views/user/listUsers.html",
            controller: "UserController"
        })
        .when("/user/edit/:id", {
            templateUrl: "../views/user/editUser.html",
            controller: "UserController"
        })
        .when("/category", {
            templateUrl: "../views/category/category.html",
            controller: "CategoryController"
        })
        .when("/category/list", {
            templateUrl: "../views/category/listCategories.html",
            controller: "CategoryController"
        })
        .when("/category/edit/:id", {
            templateUrl: "../views/category/editCategory.html",
            controller: "CategoryController"
        })
        .when("/supplier", {
            templateUrl: "../views/supplier/supplier.html",
            controller: "SupplierController"
        })
        .when("/supplier/list", {
            templateUrl: "../views/supplier/listSuppliers.html",
            controller: "SupplierController"
        })
        .when("/supplier/edit/:id", {
            templateUrl: "../views/supplier/editSupplier.html",
            controller: "SupplierController"
        })
        .when("/proposal", {
            templateUrl: "../views/proposal/proposal.html",
            controller: "ProposalController"
        })
        .when("/proposal/list", {
            templateUrl: "../views/proposal/listProposals.html",
            controller: "ProposalController"
        })
        .when("/proposal/edit/:id", {
            templateUrl: "../views/proposal/editProposal.html",
            controller: "ProposalController"
        })
        .when("/configuration", {
            templateUrl: "../views/configuration/editConfiguration.html",
            controller: "ConfigurationController"
        });
});