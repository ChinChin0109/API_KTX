<template>
  <div class="wrapper">
      <div class="inner">
            <form @submit.prevent="handleSubmit">
            <h3 class="title-department">Update</h3>

            <div class = "input-group mb-3">
                <span class="input-group-text">Employee ID</span>
                <input type="text" class="form-control" v-model="emp.employeeId" disabled>
            </div>
            <div class = "input-group mb-3">
                <span class="input-group-text">Employee Name</span>
                <input type="text" class="form-control" v-model="emp.employeeName" required>
            </div>
            <div class="input-group mb-3">
                <span class="input-group-text">Department</span>
                <select class="form-select" v-model ="department">
                <option selected>{{department}}</option>
                <option v-for="(dep,index) in departments" :key="index">
                {{dep.departmentName}}</option>
                </select>
            </div>
            <div class = "input-group mb-3">
                <span class="input-group-text">Date Of Join</span>
                <input type="date" class="form-control" v-model="emp.dateOfJoin">
            </div>
            <div class="input-group mb-3 ">
                <span class="input-group-text">Avatar</span>
                <img width="250px" height="250px"
                    :src="photoPath+photoFileName"/>
                <input class="m-2" type="file" @change="imageUpload">
            </div>
            <button class="btn btn-block btn-change">Update</button>

        </form>
      </div>
  </div>
</template>

<script>

const Token = localStorage.getItem('token');
import AxiosAuth from '@/utils/axios.utils';
//const URL_PHOTO = 'https://localhost:44382/Photos/';

export default {
  name: "UpdateEmp",
  data() {
    return {
        emp:{},
        employeeId:0,
        employeeName:"",
        department:"",
        dateOfJoin:"",
        photoFileName:"",
        photoPath: 'https://localhost:44382/Photos/',
        departments:[],
        departmentName: "",
        selected: null
    };
  },
  created() {
        let uri = `https://localhost:44382/api/employee/${this.$route.params.id}`;
        AxiosAuth.instance().get(uri).then((response) => {
            this.emp = response.data;
        });
        AxiosAuth.instance().get("department").then((response) => {
            this.departments = response.data;
        });
  },
  methods: {
    handleSubmit() {
        var that = this;

        AxiosAuth.instance().put("employee",
        {
            employeeId:this.emp.employeeId,
            employeeName:this.emp.employeeName,
            department:this.emp.department,
            dateOfJoin:this.emp.dateOfJoin,
            photoFileName:this.emp.photoFileName
        },
        {
        headers: {
            'Authorization': `Bearer ${Token}`,
            'Accept': '*/*',
            'Content-Type': 'application/json; charset=utf-8'
            }
        })
        .then(
            (response)=>{
            console.log(response.data);
                alert("Update successfully");
                    that.$router.push("/employee");
    
            },
            function () {
            alert("Update failed");
            }
        );
  
    },
    imageUpload(event)
        {
            let formData = new FormData();
            formData.append('file',event.target.files[0]);
            AxiosAuth.instance().post("employee/savefile", formData,
            {
            headers: {
                    'Authorization': `Bearer ${Token}`,
                    'Accept': '*/*',
                    'Content-Type': 'application/json; charset=utf-8'
                }
            })
            .then((response)=>
            {
                this.PhotoFileName=response.data;
            }
            );
        }
  },
};
</script>
