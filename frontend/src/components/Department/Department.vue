<template>
<div>
    <div class="auth-wrapper">
        <div class="auth-inner">
            <router-link to="/createdepartment" class="btn m-2 fload-end add">Add Department</router-link>
            <table class="table table-striped">
                <thead>
                    <tr>
                        <th>
                            DepartmentId
                        </th>
                        <th>
                            DepartmentName
                        </th>
                        <th >
                            Options
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="(dep, index) in displayedDepartment" :key="index">
                        <td>{{dep.departmentId}}</td>
                        <td>{{dep.departmentName}}</td>
                        <td>
                             <router-link :to="{name: 'updatedepartment', params: { id: dep.departmentId }}" class="btn edit">
                                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-pencil-square" viewBox="0 0 16 16">
                                <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z"/>
                                <path fill-rule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z"/>
                                </svg>
                             </router-link>
                            <button type="button" @click ="deleteClick(dep.departmentId)"
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
                <span class="choose" v-for="(pageNumber,undex) in pages.slice(page-1, page+5)" :key="undex" >
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
            departments:[''],
            modalTitle:"",
            departmentId:0,
            departmentName:"",
            page: 1,
            perPage: 5,
            pages: [],
        }
    },
    methods:{
        refreshData()
        {
           // console.log(token);
           if(Token)
           {
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
            });
           }
            

        },
        deleteClick(id)
        {
            if(!confirm("Are you sure?"))
            {
                return;
            }

            AxiosAuth.instance().delete("department/"+id)
            .then(
                (response) =>{
                    console.log(response.data);
                    this.refreshData();
                    alert("Delete successfully");
                }
            )
        },
        setPages() {
            let numberOfpages = Math.ceil(this.departments.length / this.perPage);
            for(let index = 1; index <= numberOfpages; index++)
            {
                this.pages.push(index);
            }
        },
        paginate (departments) {
            let page = this.page;
            let perPage = this.perPage;
            let from = (page * perPage) - perPage;
            let to = (page * perPage);
            return departments.slice(from, to);
        }
    },
    // mounted:function()
    // {
    //     this.refreshData();
    // }
    computed: {
        displayedDepartment() {
            return this.paginate(this.departments);
        }
    },
    watch: {
        departments() {
            this.setPages();
        }
    },
    created() {
        this.refreshData();
    },
    filters: {
        triWords(value) {
            return value.split(" ").splice(0,20).join(" ")+ '...';
        }
    }
}
</script>

<style>

    .auth-wrapper {
    display: flex;
    justify-content: center;
    flex-direction: column;
    padding-top: 130px;
    text-align: left;
    }

    .auth-inner{
    width: 1000px;
    padding-top: 0px;
    margin: auto;
    background: #ffffff;
    box-shadow: 0px 14pz 80px rgba(34,35,58,0.2);
    padding: 40px 55px 45px 55px;
    border-radius: 15px;
    transition: all .3s;
    }
    .auth-wrapper .form-control:focus{
    border-color: #167bff;
    box-shadow: none;
    }

    .edit {
        color: #000;
    }
    .edit:hover {
        background-color: rgb(228, 224, 224);
    }
    .add:hover{
        color: #FFFFFF;
        background-color: rosybrown;
    }
    .pagination-row {
        justify-content: center;
        text-align: center;
    }
    .pagination-button {
        padding: 7px;
        margin: 2px;
        border-radius: 5px;
        font-size: 1em;
        cursor: pointer;
    }

    .pagination-button:hover {
        color: #FFFFFF;
        background-color: rosybrown;
    }
    /* .choose{
        color: #FFFFFF;
        background-color: rosybrown !important;
    } */
</style>

