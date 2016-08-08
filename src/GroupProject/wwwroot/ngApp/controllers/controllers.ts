namespace GroupProject.Controllers {

    export class HomeController {
        public message = 'Hello from the home page!';
    }

    export class EventSearchController {
        public eventSearchData;

        constructor(private $http: ng.IHttpService) {
            $http.get('/api/event')
                .then((response) => {
                    this.eventSearchData = response.data;
                });
        }
    }

    export class SecretController {
        public secrets;

        constructor($http: ng.IHttpService) {
            $http.get('/api/secrets').then((results) => {
                this.secrets = results.data;
            });
        }
    }


    export class AboutController {
        public message = 'Hello from the about page!';
    }

    export class UserController {
        public userData;

        /*constructor(private $http: ng.IHttpService) {
            $http.get().then((results) => {
                this.userData = results.data;
            });
        }*/


    }

    export class GroupController {

        public users;

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService) {
            $http.get('/api/user').then((results) => {
                this.users = results.data;
            });
        }

        public addGroup(group) {
            this.$http.post('/api/groups', group)
                .then((response) => {
                    this.$state.reload();
                })
                .catch((reason) => {
                    console.log(reason);
                });

        }

    }

}
