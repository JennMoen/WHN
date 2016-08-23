namespace GroupProject.Controllers {

    export class HomeController {
        public message = 'Hello from the home page!';
    }

    export class EventSearchController {
        public eventSearchData;
        public categories;
        

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService, private $stateParams: ng.ui.IStateParamsService, private $scope) {
            
            $http.get('/api/events')
                .then((response) => {
                    this.eventSearchData = response.data;
                    for (let i = 0; i < this.eventSearchData.length; i++) {
                        this.eventSearchData[i].numLimit = 100;
                    }
                });
            //constructor info used to build the 'search by category' pull-down
            $http.get('/api/category')
                .then((response) => {
                    this.categories = response.data;
                });
        }



        public readMore(searchData) {

        }


        public Attend(eventId) {
            this.$http.post(`/api/events/attend`, eventId)
                .then((response) => {
                    this.$state.reload();
                })
                .catch((reason) => {
                    console.log(reason);

                });
        }

        public showWords(s) {
            s.numLimit = 10000;
            
            
        }
    }

    export class EventAddController {
        public categories;
        public eventStatus;
        public myGroups;
        public toastMsg;
        public displayToast($mdToast) {
            var toast = $mdToast.simple()
                .textContent(this.toastMsg)
                .position('bottom left')
                .hideDelay(5000);

            $mdToast.show(toast);
        };

        
        // Post the new event to the database
        public addEvent(addEvent) {

            addEvent.admissionPrice = addEvent.admissionPrice;
            addEvent.categoryId = addEvent.category.id;
            addEvent.dateCreated = moment();
            addEvent.dateOfEvent = addEvent.startDate;
            addEvent.description = addEvent.description;
            addEvent.endTime = addEvent.endDate;
            addEvent.location = addEvent.location;
            addEvent.name = addEvent.name;
            addEvent.status = addEvent.status;
            addEvent.group = addEvent.group;

            console.log(`price: ${addEvent.admissionPrice} category ID:  ${addEvent.category.id}`);
            console.log(`category name: ${addEvent.category.name}`);
            console.log(`date created: ${addEvent.dateCreated} end time: ${addEvent.endTime}`);
            console.log(`description: ${addEvent.description}`);
            console.log(`date of event: ${addEvent.dateOfEvent} location: ${addEvent.location}`);
            console.log(`name: ${addEvent.name}`);
            console.log(`status: ${addEvent.status}`);
            console.log(`group name: ${addEvent.group}`);
            

            this.$http.post('/api/events', addEvent)

                .then((response) => {
                    console.log("Success: response");
                    this.$state.reload();
                    this.toastMsg = "Your event was added successfully";
                    this.displayToast(this.$mdToast);
                })
                .catch((reason) => {
                    console.log("Error: " + reason);
                });

        }

        //constructor info used to build the 'add event' category pull-down, the groups checkbox, and the event status radio buttons
        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService, private $mdToast: ng.material.IToastService, private accountService: GroupProject.Services.AccountService) {
            // make sure the user is logged in
            if (!accountService.isLoggedIn()) {
                this.$state.go('home');
                this.toastMsg = "Please log in before adding an event";
                this.displayToast(this.$mdToast);
            }

            $http.get('/api/category')
                .then((response) => {
                    this.categories = response.data;
                }),

                $http.get('/api/groups/createdgroups').then((results) => {
                this.myGroups = results.data;
                }),

            this.eventStatus = [
                "private",
                "public"
            ];


        }
    };



    export class EventController {
        public event;


        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService) { }

        public addEvent(event) {
            this.$http.post('/api/events', event)
                .then((response) => {
                    this.$state.reload();
                })
                .catch((reason) => {
                    console.log(reason);

                });

            this.$http.delete('/api/events', event)
                .then((response) => {
                    this.$state.reload();


                })
        };
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

    export class MyGroupsController {

        public myGroups;
        public events;
        public groups;

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService) {
            $http.get('/api/groups/createdgroups').then((results) => {
                this.myGroups = results.data;
            });
            $http.get('/api/groups/mygroups').then((results) => {
                this.groups = results.data;
            });
        }

        public addGroup(group) {
            this.$http.post('/api/groups', group)
                .then((response) => {
                    this.$state.go('myGroups');
                })
                .catch((reason) => {
                    console.log(reason);
                });
        }

        public leaveGroup(groupId) {
            console.log(groupId);
            var p = { groupId: groupId };
            //this.$http.delete(`/api/events/${event.id}`, event)
            this.$http.delete(`/api/groups/mygroups`, { params: p })
                .then((response) => {
                    this.$state.reload();

                });
        }
    }




    export class MyGroupDetailsController {
        public group;
        public events;
        public users;
        public eventGroups;

        constructor(private $http: ng.IHttpService, private $stateParams, private $state: ng.ui.IStateService) {
            $http.get(`/api/groups/${$stateParams['id']}`)
                .then((response) => {
                    this.group = response.data;
                });
            $http.get('/api/user').then((results) => {
                this.users = results.data;
            });
            $http.get('/api/events')
                .then((response) => {
                    this.events = response.data;
                    console.log(this.events);
                });
            $http.get(`/api/eventgroups/${this.$stateParams.id}/groupevents`).then((results) => {
                this.eventGroups = results.data;
            });
        }

        public updateGroup(group) {
            var p = { groupId: this.$stateParams.id };
            this.$http.put(`/api/groups/${this.$stateParams.id}`, group, { params: p })
                .then((response) => {
                    this.$state.reload();
                }).catch((reason) => {
                    console.log(reason);
                });
        }

        public deleteGroup(group) {
            this.$http.delete(`/api/groups/${this.$stateParams.id}`, group)
                .then((response) => {
                    this.$state.go('myGroups');

                });
        }

        public groupAttend(eventId) {

            this.$http.post(`/api/eventgroups/${this.$stateParams.id}/attend`, eventId)
                .then((response) => {
                    this.$state.reload();
                })
                .catch((reason) => {
                    console.log(reason);
                    console.log("You screwed up all sorts of bad");
                    console.log(eventId);
                });

        }

        public deleteEvent(eventId) {
            var p = { eventId: eventId };
            console.log(eventId);
            //this.$http.delete(`/api/events/${event.id}`, event)
            this.$http.delete(`/api/eventgroups/${this.$stateParams.id}/groupevents`, { params: p })
                .then((response) => {
                    this.$state.reload();

                });
        }

    }

    //not in use for now--lets you add a person to your group
    //public addMember(m) {
    //    var member = JSON.stringify(m);
    //    this.$http.post(`/api/groups/${this.$stateParams.id}/members`, member)
    //        .then((response) => {
    //            this.$state.reload();
    //        })
    //        .catch((reason) => {
    //            console.log(member);
    //            console.log(reason);
    //        });
    //}

    export class GroupController {

        public groups;
        

        constructor(private $http: ng.IHttpService, private $state: ng.ui.IStateService) {
            $http.get('/api/groups').then((results) => {
                this.groups = results.data;
            });

        }



    }

    export class GroupDetailsController {
        public group;
        public users;
        public eventGroups;

        constructor(private $http: ng.IHttpService, private $stateParams, private $state: ng.ui.IStateService) {
            $http.get(`/api/groups/${$stateParams['id']}`)
                .then((response) => {
                    this.group = response.data;
                });
            $http.get('/api/user').then((results) => {
                this.users = results.data;
            });
            $http.get(`/api/eventgroups/${this.$stateParams.id}/groupevents`).then((results) => {
                this.eventGroups = results.data;
            });
        }



        public Join(groupId) {
            this.$http.post(`/api/groups/join`, groupId
            )
                .then((response) => {
                    this.$state.reload();
                })
                .catch((reason) => {
                    console.log(reason);

                });
        }


    }

    export class MyEventsController {

        //public eventSearchData;
        //constructor(private $http: ng.IHttpService) {
        //    $http.get('/api/events')
        //        .then((response) => {
        //            this.eventSearchData = response.data;
        //        })
        //};

        public events;
        public myevents;


        constructor(private $http: ng.IHttpService, private $stateParams: ng.ui.IStateParamsService, private $state: ng.ui.IStateService) {

            $http.get(`/api/events/myevents`)
                .then((response) => {
                    this.events = response.data;
                });
            $http.get('/api/events/mycreatedevents')
                .then((response) => {
                    this.myevents = response.data;
                });
        }

        public deleteEvent(eventId) {
            console.log(eventId);
            var p = { eventId: eventId };
            //this.$http.delete(`/api/events/${event.id}`, event)
            this.$http.delete(`/api/events/myevents`, { params: p })
                .then((response) => {
                    this.$state.reload();

                });
        }

    }

    export class EditEventController {

        //public editing
        //constructor(private $http: ng.IHttpService) {
        //    $http.get('/api/events')
        //        .then((response) => {
        //            this.editing = response.data;
        //        })


        public event;
        public categories;
        public eventStatus;
        public toastMsg;
        public displayToast($mdToast) {
            var toast = $mdToast.simple()
                .textContent(this.toastMsg)
                .position('bottom left')
                .hideDelay(5000);

            $mdToast.show(toast);
        };

        constructor(private $http: ng.IHttpService, private $stateParams, private $state: ng.ui.IStateService, private $mdToast: ng.material.IToastService) {
            var p = { eventId: $stateParams.id };

            $http.get(`/api/events/${$stateParams.id}`, { params: p })
                .then((response) => {
                    this.event = response.data;
                    if (this.event.status == "public") {
                        this.event.status.checked = "public"
                    } else {
                        this.event.status.checked = "private"
                    }
                    this.eventStatus = [
                        "private", "public"]
                   
                        
                }),

            $http.get('/api/category')
                .then((response) => {
                    this.categories = response.data;
                });

        }



        public updateEvent(event) {
            var p = { eventId: this.$stateParams.id };
            this.$http.put(`/api/events/${this.$stateParams.id}`, event, { params: p })
                .then((response) => {
                    this.$state.go('eventSearch');
                    this.toastMsg = "Your event was updated successfully";
                    this.displayToast(this.$mdToast);
                }).catch((reason) => {
                    console.log(reason);
                });
        }

        public deleteEvent(event) {
            this.$http.delete(`/api/events/${this.$stateParams.id}`, event)
                .then((response) => {
                    this.$state.go('eventSearch');
                    this.toastMsg = "Your event was successfully deleted";
                    this.displayToast(this.$mdToast);
                }).catch((reason) => {
                    console.log(reason);
                });

        }


    }


    //public editing
    //constructor(private $http: ng.IHttpService) {
    //    $http.get('/api/events')
    //        .then((response) => {
    //            this.editing = response.data;
    //        })
    //}
    //$http.get(`/api/events/${this.eInfo.id}`)
    //    .then((response) =>
    //    {
    //        this.eInfo = response.data;
    //    })


    export class EventDetailsController {
        public eventSearchData;
        public groups;

        constructor(private $http: ng.IHttpService, private $stateParams) {
            var p = { eventId: $stateParams.id };

            $http.get(`/api/events/${$stateParams.id}`, { params: p })
                .then((response) => {
                    this.eventSearchData = response.data;
                });
            $http.get(`/api/eventgroups/${$stateParams.id}/groupsattending`, { params: p })
                .then((response) => {
                    this.groups = response.data;
                });
        }

    }



    export class TestController {
        public testData;

        public TestController() {

        }
    }

}











