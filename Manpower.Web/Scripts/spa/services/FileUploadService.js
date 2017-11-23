(function (app) {
    'use strict';

    app.factory('FileUploadService', FileUploadService);

    FileUploadService.$inject = ['$http', '$q', 'notificationService'];

    function FileUploadService($http, $q, notificationService) {

        //applicant picuture
        function UploadApplicantInfo(file) {
            var formData = new FormData();
            formData.append("file", file);

            var defer = $q.defer();
            $http.post("/Home/UploadApplicantImage", formData,
                {
                    withCredentials: true,
                    headers: { 'Content-Type': undefined },
                    transformRequest: angular.identity
                })
            .success(function (d) {
                defer.resolve(d);
                notificationService.displaySuccess('Applicant Image Uploaded.');
            })
            .error(function () {
                defer.reject("");
                notificationService.displayError("Applicant Image Upload Failed !");
            });

            return defer.promise;

        }

        //passport
        function UploadPassport(file) {
            var formData = new FormData();
            formData.append("file", file);

            var defer = $q.defer();
            $http.post("/Home/UploadPassport", formData,
                {
                    withCredentials: true,
                    headers: { 'Content-Type': undefined },
                    transformRequest: angular.identity
                })
            .success(function (d) {
                defer.resolve(d);
                notificationService.displaySuccess('Passport Uploaded.');
            })
            .error(function () {
                defer.reject("");
                notificationService.displayError("Passport Upload Failed !");
            });

            return defer.promise;

        }

        //Certificates
        function UploadCertificate(file) {
            var formData = new FormData();
            formData.append("file", file);

            var defer = $q.defer();
            $http.post("/Home/UploadCertificate", formData,
                {
                    withCredentials: true,
                    headers: { 'Content-Type': undefined },
                    transformRequest: angular.identity
                })
            .success(function (d) {
                defer.resolve(d);
                notificationService.displaySuccess('Certificates Uploaded.');
            })
            .error(function () {
                defer.reject("");
                notificationService.displayError("Certificates Upload Failed !");
            });

            return defer.promise;

        }

        //Client Certificates
        function UploadClientCertificate(file) {
            var formData = new FormData();
            formData.append("file", file);

            var defer = $q.defer();
            $http.post("/Home/UploadClientCertificate", formData,
                {
                    withCredentials: true,
                    headers: { 'Content-Type': undefined },
                    transformRequest: angular.identity
                })
            .success(function (d) {
                defer.resolve(d);
                notificationService.displaySuccess('Certificates Uploaded.');
            })
            .error(function () {
                defer.reject("");
                notificationService.displayError("Certificates Upload Failed !");
            });

            return defer.promise;

        }

        //Client Certificates
        function UploadPostCertificate(file) {
            var formData = new FormData();
            formData.append("file", file);

            var defer = $q.defer();
            $http.post("/Home/UploadPostCertificate", formData,
                {
                    withCredentials: true,
                    headers: { 'Content-Type': undefined },
                    transformRequest: angular.identity
                })
            .success(function (d) {
                defer.resolve(d);
                notificationService.displaySuccess('Certificates Uploaded.');
            })
            .error(function () {
                defer.reject("");
                notificationService.displayError("Certificates Upload Failed !");
            });

            return defer.promise;

        }
        //Sales
        function UploadSales(file) {
            var formData = new FormData();
            formData.append("file", file);

            var defer = $q.defer();
            $http.post("/Home/UploadSales", formData,
                {
                    withCredentials: true,
                    headers: { 'Content-Type': undefined },
                    transformRequest: angular.identity
                })
            .success(function (d) {
                defer.resolve(d);
                notificationService.displaySuccess('Sales Bill Uploaded.');
            })
            .error(function () {
                defer.reject("");
                notificationService.displayError("Sales Bill Upload Failed !");
            });

            return defer.promise;

        }
        //Purchase
        function UploadPurchase(file) {
            var formData = new FormData();
            formData.append("file", file);

            var defer = $q.defer();
            $http.post("/Home/UploadPurchase", formData,
                {
                    withCredentials: true,
                    headers: { 'Content-Type': undefined },
                    transformRequest: angular.identity
                })
            .success(function (d) {
                defer.resolve(d);
                notificationService.displaySuccess('Purchase Bill Uploaded.');
            })
            .error(function () {
                defer.reject("");
                notificationService.displayError("Purchase Bill Upload Failed !");
            });

            return defer.promise;

        }
        //Expense
        function UploadExpense(file) {
            var formData = new FormData();
            formData.append("file", file);

            var defer = $q.defer();
            $http.post("/Home/UploadExpense", formData,
                {
                    withCredentials: true,
                    headers: { 'Content-Type': undefined },
                    transformRequest: angular.identity
                })
            .success(function (d) {
                defer.resolve(d);
                notificationService.displaySuccess('Expenses Bill Uploaded.');
            })
            .error(function () {
                defer.reject("");
                notificationService.displayError("Expenses Bill Upload Failed !");
            });

            return defer.promise;

        }
        //Receipt
        function UploadReceipt(file) {
            var formData = new FormData();
            formData.append("file", file);

            var defer = $q.defer();
            $http.post("/Home/UploadReceipt", formData,
                {
                    withCredentials: true,
                    headers: { 'Content-Type': undefined },
                    transformRequest: angular.identity
                })
            .success(function (d) {
                defer.resolve(d);
                notificationService.displaySuccess('Receipt Bill Uploaded.');
            })
            .error(function () {
                defer.reject("");
                notificationService.displayError("Receipt Bill Upload Failed !");
            });

            return defer.promise;

        }
        //Payment
        function UploadPayment(file) {
            var formData = new FormData();
            formData.append("file", file);

            var defer = $q.defer();
            $http.post("/Home/UploadPayment", formData,
                {
                    withCredentials: true,
                    headers: { 'Content-Type': undefined },
                    transformRequest: angular.identity
                })
            .success(function (d) {
                defer.resolve(d);
                notificationService.displaySuccess('Payment Bill Uploaded.');
            })
            .error(function () {
                defer.reject("");
                notificationService.displayError("Payment Bill Upload Failed !");
            });

            return defer.promise;

        }
        //Bill
        function UploadBill(file) {
            var formData = new FormData();
            formData.append("file", file);

            var defer = $q.defer();
            $http.post("/Home/UploadBill", formData,
                {
                    withCredentials: true,
                    headers: { 'Content-Type': undefined },
                    transformRequest: angular.identity
                })
            .success(function (d) {
                defer.resolve(d);
                notificationService.displaySuccess('Bill Uploaded.');
            })
            .error(function () {
                defer.reject("");
                notificationService.displayError("Bill Upload Failed !");
            });

            return defer.promise;

        }
        return {
            UploadApplicantInfo: UploadApplicantInfo,
            UploadPassport: UploadPassport,
            UploadCertificate: UploadCertificate,
            UploadClientCertificate: UploadClientCertificate,
            UploadPostCertificate: UploadPostCertificate,
            UploadSales: UploadSales,
            UploadPurchase: UploadPurchase,
            UploadExpense: UploadExpense,
            UploadReceipt: UploadReceipt,
            UploadPayment: UploadPayment,
            UploadBill: UploadBill
        };
    }

})(angular.module('common.core'));