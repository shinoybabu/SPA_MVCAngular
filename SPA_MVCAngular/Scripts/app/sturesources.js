/// <reference path="../angular.js" />
var sturesources = angular.module("sturesources", ['ngResource']);
console.log("inside StuResource")
sturesources.controller("Studs", function Studs($resource) {
    return $resource("api/Students", {}, {
        query: { method: 'GET', params: {}, isArray:true}
    });    
});