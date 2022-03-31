<template>
  <div class="wrapper">
      <div class="inner">
            <form @submit.prevent="handleSubmit">
            <h3 class="title-department">Create</h3>

            <div class = "input-group mb-3">
                <span class="input-group-text">Employee Name</span>
                <input type="text" class="form-control" v-model="employeeName" required>
            </div>
            <div class="input-group mb-3">
                <span class="input-group-text">Department</span>
                <select class="form-select" v-model ="department">
                <option v-for="(dep,index) in departments" :key="index">
                {{dep.departmentName}}</option>
                </select>
            </div>
            <div class = "input-group mb-3">
                <span class="input-group-text">Date Of Join</span>
                <input type="date" class="form-control" v-model="dateOfJoin">
            </div>
            <div class="input-group mb-3 ">
                <span class="input-group-text">Avatar</span>
                <img width="250px" height="250px"
                    :src="photoPath+photoFileName"/>
                <input class="m-2" type="file" @change="imageUpload">
            </div>
            <button class="btn btn-block btn-change">Add</button>

        </form>
      </div>
  </div>
</template>

<script>

const Token = localStorage.getItem('token');
import AxiosAuth from '@/utils/axios.utils';
const URL_PHOTO = 'https://localhost:44382/Photos/';

export default {
  name: "CreateEmp",
  data() {
    return {
        emp:{},
        employeeName:"",
        department:"",
        dateOfJoin:"",
        photoFileName:"",
        photoPath: URL_PHOTO,
        departments:[],
        departmentName: "",
    };
  },
  created() {
        AxiosAuth.instance().get("department").then((response) => {
            this.departments = response.data;
        });
  },
  methods: {
    handleSubmit() {
        var that = this;

        AxiosAuth.instance().post("employee",
        {
            employeeName:this.employeeName,
            department:this.department,
            dateOfJoin:this.dateOfJoin,
            photoFileName:this.photoFileName
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
                alert("Create successfully");
                    that.$router.push("/employee");
    
            },
            function () {
            alert("Create failed");
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

<style>
span {
    width: 140px;
    margin-right: 10px;
}
select {
    width: 240px;
}
</style>
