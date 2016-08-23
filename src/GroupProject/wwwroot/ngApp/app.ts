namespace GroupProject {

    angular.module('GroupProject', ['ui.router', 'ngResource', 'ngMaterial', 'ngMaterialDatePicker', 'ngMessages', 'ngMdIcons']).config((
        //'ui.bootstrap' after resource
        //'ngMdIcons' after messages
        $stateProvider: ng.ui.IStateProvider,
        $urlRouterProvider: ng.ui.IUrlRouterProvider,
        $locationProvider: ng.ILocationProvider,
        $mdThemingProvider: ng.material.IThemingProvider

    ) => {
        // Define routes
        $stateProvider
            .state('home', {
                url: '/',
                templateUrl: '/ngApp/views/home.html',
                controller: GroupProject.Controllers.HomeController,
                controllerAs: 'controller'
            })
            .state('eventSearch', {
                url: '/eventSearch',
                templateUrl: '/ngApp/views/EventSearch.html',
                controller: GroupProject.Controllers.EventSearchController,
                controllerAs: 'controller'
            })
            .state('eventAdd', {
                url: '/eventAdd',
                templateUrl: '/ngApp/views/eventAdd.html',
                controller: GroupProject.Controllers.EventAddController,
                controllerAs: 'controller'
            })
            .state('secret', {
                url: '/secret',
                templateUrl: '/ngApp/views/secret.html',
                controller: GroupProject.Controllers.SecretController,
                controllerAs: 'controller'
            })
            .state('login', {
                url: '/login',
                templateUrl: '/ngApp/views/login.html',
                controller: GroupProject.Controllers.LoginController,
                controllerAs: 'controller'
            })
            .state('register', {
                url: '/register',
                templateUrl: '/ngApp/views/register.html',
                controller: GroupProject.Controllers.RegisterController,
                controllerAs: 'controller'
            })
            .state('externalRegister', {
                url: '/externalRegister',
                templateUrl: '/ngApp/views/externalRegister.html',
                controller: GroupProject.Controllers.ExternalRegisterController,
                controllerAs: 'controller'
            })
            .state('about', {
                url: '/about',
                templateUrl: '/ngApp/views/about.html',
                controller: GroupProject.Controllers.AboutController,
                controllerAs: 'controller'
            })
            .state('myaccount', {
                url: '/myaccount',
                templateUrl: '/ngApp/views/myaccount.html',
                controller: GroupProject.Controllers.UserController,
                controllerAs: 'controller'
            })
            .state('groups', {
                url: '/groups',
                templateUrl: '/ngApp/views/groups.html',
                controller: GroupProject.Controllers.GroupController,
                controllerAs: 'controller'
            })
            .state('groupDetails', {
                url: '/groupDetails/:id',
                templateUrl: '/ngApp/views/groupDetails.html',
                controller: GroupProject.Controllers.GroupDetailsController,
                controllerAs: 'controller'
            })
            .state('myGroups', {
                url: '/myGroups',
                templateUrl: '/ngApp/views/myGroups.html',
                controller: GroupProject.Controllers.MyGroupsController,
                controllerAs: 'controller'
            })
            .state('myGroupDetails', {
                url: '/myGroupDetails/ :id',
                templateUrl: '/ngApp/views/myGroupDetails.html',
                controller: GroupProject.Controllers.MyGroupDetailsController,
                controllerAs: 'controller'
            })
            .state('createGroup', {
                url: '/createGroup',
                templateUrl: '/ngApp/views/createGroup.html',
                controller: GroupProject.Controllers.MyGroupsController,
                controllerAs: 'controller'
            })
            .state('eventadd', {
                url: '/eventadd',
                templateUrl: '/ngApp/views/eventadd.html',
                controller: GroupProject.Controllers.EventController,
                controllerAs: 'controller'
            })
            .state('MyEvents', {
                url: '/MyEvents',
                templateUrl: '/ngApp/views/MyEvents.html',
                controller: GroupProject.Controllers.MyEventsController,
                controllerAs: 'controller'

            })
            .state('editEvent', {
                url: '/editEvent/:id',
                templateUrl: '/ngApp/views/editEvent.html',
                controller: GroupProject.Controllers.EditEventController,
                controllerAs: 'controller'
            })
            .state('EventDetails', {
                url: '/EventDetails/:id',
                templateUrl: '/ngApp/views/EventDetails.html',
                controller: GroupProject.Controllers.EventDetailsController,
                controllerAs: 'controller'
            })
            .state('test', {
                url: '/test',

                templateUrl: '/ngApp/views/test.html',
                controller: GroupProject.Controllers.TestController,
                controllerAs: 'controller'
            })
            .state('notFound', {
                url: '/notFound',
                templateUrl: '/ngApp/views/notFound.html'
            });


        // Handle request for non-existent route
        $urlRouterProvider.otherwise('/notFound');

        // Enable HTML5 navigation
        $locationProvider.html5Mode(true);

        $mdThemingProvider.theme('default')
            .primaryPalette('grey', {
                'default': '900',
                'hue-1': '50',
                'hue-2': '500',
                'hue-3': '700'
            })
                .accentPalette('red')
                .warnPalette('orange')
        });



        angular.module('GroupProject').factory('authInterceptor', (
            $q: ng.IQService,
            $window: ng.IWindowService,
            $location: ng.ILocationService
        ) =>
            ({
                request: function (config) {
                    config.headers = config.headers || {};
                    config.headers['X-Requested-With'] = 'XMLHttpRequest';
                    return config;
                },
                responseError: function (rejection) {
                    if (rejection.status === 401 || rejection.status === 403) {
                        $location.path('/login');
                    }
                    return $q.reject(rejection);
                }
            })
        );

        angular.module('GroupProject').config(function ($httpProvider) {
            $httpProvider.interceptors.push('authInterceptor');
        });


    }
       