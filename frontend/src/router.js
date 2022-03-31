import { createWebHistory, createRouter } from "vue-router";
import Home from "./components/Home.vue";
import Login from "./components/Login.vue";
import Register from "./components/Register.vue";
import Profile from "./components/Profile.vue";
import Department from "@/components/Department/Department.vue";
import UpdateDep from "@/components/Department/UpdateDep.vue";
import CreateDep from "@/components/Department/CreateDep.vue";
import Employee from "@/components/Employee/Employee.vue";
import UpdateEmp from "@/components/Employee/UpdateEmp.vue";
import CreateEmp from "@/components/Employee/CreateEmp.vue";
import DienNuoc from "@/components/DienNuoc/DienNuoc.vue";
import Phong from "@/components/Phong/Phong.vue";
import PhongInfo from "@/components/Phong/PhongInfo.vue";

const routes = [
  {
    path: "/",
    name: "home",
    component: Home,
  },
  {
    path: "/login",
    component: Login,
  },
  {
    path: "/register",
    component: Register,
  },
  {
    path: "/department",
    component: Department,
  },
  {
    path: "/updatedepartment",
    name: "updatedepartment",
    component: UpdateDep,
  },
  {
    path: "/createdepartment",
    name: "createdepartment",
    component: CreateDep,
  },
  {
    path: "/profile",
    name: "profile",
    component: Profile,
  },
  {
    path: "/employee",
    name: "employee",
    component: Employee,
  },
  {
    path: "/updateemployee",
    name: "updateemployee",
    component: UpdateEmp,
  },
  {
    path: "/addemployee",
    name: "addemployee",
    component: CreateEmp,
  },
  {
    path: "/diennuoc",
    name: "diennuoc",
    component: DienNuoc,
  },
  {
    path: "/phong",
    name: "phong",
    component: Phong,
  },
  {
    path: "/phonginfo",
    name: "phonginfo",
    component: PhongInfo,
  }
];

const router = createRouter({
  history: createWebHistory(),
  routes,
});

export default router;