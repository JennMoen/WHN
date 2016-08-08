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

        public readMore(searchData) {
            
            
        }
    }

    export class EventAddController {
        public categories;

        constructor(private $http: ng.IHttpService) {
            $http.get('/api/category')
                .then((response) =>  {
                this.categories = response.data;
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

}
