<template>
<div>
    <div class="auth-wrapper">
        <div class="auth-inner">
            <router-link to="/addemployee" class="btn m-2 fload-end add">Add Employee</router-link>
            <table class="table table-striped">
                <thead>
                    <tr>
                        <th>
                            EmployeeId
                        </th>
                        <th>
                            EmployeeName
                        </th>
                        <th>
                            Department
                        </th>
                        <th>
                            Date of Join
                        </th>
                        <th>
                            Avatar
                        </th>
                        <th>
                            Options
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="(emp, index) in displayedEmployee" :key="index">
                        <td>{{emp.employeeId}}</td>
                        <td>{{emp.employeeName}}</td>
                        <td>{{emp.department}}</td>
                        <td>{{emp.dateOfJoin}}</td>
                        <td><img :src="image"></td>
                        <td>
                             <router-link :to="{name: 'updateemployee', params: { id: emp.employeeId }}" class="btn edit">
                                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-pencil-square" viewBox="0 0 16 16">
                                <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z"/>
                                <path fill-rule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z"/>
                                </svg>
                             </router-link>
                            <button type="button" @click ="deleteClick(emp.employeeId)"
                            class="btn btn-light mr-1">
                                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash-fill" viewBox="0 0 16 16">
                                <path d="M2.5 1a1 1 0 0 0-1 1v1a1 1 0 0 0 1 1H3v9a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V4h.5a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H10a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1H2.5zm3 4a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 .5-.5zM8 5a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7A.5.5 0 0 1 8 5zm3 .5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 1 0z"/>
                                </svg>
                            </button>
                        </td>
                    </tr>
                </tbody>
            </table>
            <div class="pagination-row">
                <button class="pagination-button" v-if="page != 1" @click="page--">&lt;&lt;</button>
                <span v-for="(pageNumber,undex) in pages.slice(page-1, page+5)" :key="undex" >
                    <button class="pagination-button"
                            @click="page = pageNumber">
                         {{pageNumber}} 
                    </button>
                </span>
                <button class="pagination-button" @click="page++" v-if="page < pages.length">&gt;&gt;</button>
            </div>
        </div>
    </div>
</div>
</template>

<script>

const Token = localStorage.getItem('token');

import AxiosAuth from '@/utils/axios.utils';

export default {
     data()
    {
        return{
            departments:[],
            employees:[''],
            employeeId:0,
            employeeName:"",
            department:"",
            dateOfJoin:"",
            photoFileName:"",
            image: "",
         //   PhotoPath:variables.PHOTO_URL
            page: 1,
            perPage: 5,
            pages: [],
        }
    },
    methods:{
        refreshData()
        {
           // get department;
             AxiosAuth.instance().get('department/', {
              headers: {
                'Authorization': `Bearer ${Token}`,
                'Accept': '*/*',
                'Content-Type': 'application/json; charset=utf-8'
              }
            })
            .then((response) => {
                console.log(response);
                this.departments = response.data;
                this.photoFileName = response.photoFileName;
                this.image = `"https://localhost:44382/Photos/"${response.data.photoFileName}`;
            });
            // get employee
             AxiosAuth.instance().get('employee/', {
              headers: {
                'Authorization': `Bearer ${Token}`,
                'Accept': '*/*',
                'Content-Type': 'application/json; charset=utf-8'
              }
            })
            .then((response) => {
                console.log(response);
                this.employees = response.data;
            });

        },
        deleteClick(id)
        {
            if(!confirm("Are you sure?"))
            {
                return;
            }

            AxiosAuth.instance().delete("employee/"+id)
            .then(
                (response) =>{
                    console.log(response.data);
                    this.refreshData();
                    alert("Delete successfully");
                }
            )
        },
        setPages () {
			let numberOfPages = Math.ceil(this.employees.length / this.perPage);
			for (let index = 1; index <= numberOfPages; index++) {
				this.pages.push(index);
			}
		},
		paginate (employees) {
			let page = this.page;
			let perPage = this.perPage;
			let from = (page * perPage) - perPage;
			let to = (page * perPage);
			return  employees.slice(from, to);
		}
    },
    computed: {
		displayedEmployee () {
			return this.paginate(this.employees);
		}
	},
	watch: {
		employees () {
			this.setPages();
		}
	},
	created(){
		this.refreshData();
	},
	filters: {
		trimWords(value){
			return value.split(" ").splice(0,20).join(" ") + '...';
		}
	}

}
</script>

