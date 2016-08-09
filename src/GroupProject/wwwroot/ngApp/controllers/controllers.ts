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
        public timeSlots;       
       
        
        constructor(private $http: ng.IHttpService) {
            $http.get('/api/category')
                .then((response) => {
                    this.categories = response.data;
                });
            
            this.timeSlots = ["12:00 am", "12:30 am", "1:00 am", "1:30 am", "2:00 am", "2:30 am", "3:00 am", "3:30 am", "4:00 am", "4:30 am",
                "5:00 am", "5:30 am", "6:00 am", "6:30 am", "7:00 am", "7:30 am", "8:00 am", "8:30 am", "9:00 am", "9:30 am", "10:00 am",
                "10:30 am", "11:00 am", "11:30 am", "12:00 pm", "12:30 pm", "1:00 pm", "1:30 pm", "2:00 pm", "2:30 pm", "3:00 pm", "3:30 pm",
                "4:00 pm", "4:30 pm", "5:00 pm", "5:30 pm", "6:00 pm", "6:30 pm", "7:00 pm", "7:30 pm", "8:00 pm", "8:30 pm", "9:00 pm",
                "9:30 pm", "10:00 pm", "10:30 pm", "11:00 pm", "11:30 pm"];  

            console.log(this.timeSlots);
        }
    }


    export class EventController {
        public event;


        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService) {

            this.$http.post('/api/event', event)
                .then((response) => {
                    this.$state.go('event');
                })
                .catch((reason) => {
                    console.log(reason);

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