import axios from "axios";
import {
  Produto,
  Servico
} from "./company";

const apiBaseUrl = process.env.REACT_APP_API_URL || "http://localhost:5254/api";

export const getProdutos = async () => {
  try {
    const response = await axios.get<Produto[]>(`${apiBaseUrl}/product`);
    return response.data;
  } catch (error: any) {
    console.log("error message: ", error.message);
  }
};

export const getServicos = async () => {
  try {
    const response = await axios.get<Servico[]>(`${apiBaseUrl}/service`);
    return response.data;
  } catch (error: any) {
    console.log("error message: ", error.message);
  }
};

export const getProdutoById = async (id: string) => {
  try {
    const response = await axios.get<Produto>(`${apiBaseUrl}/product/${id}`);
    return response.data;
  } catch (error: any) {
    console.log("error message: ", error.message);
  }
};

export const getServicoById = async (id: string) => {
  try {
    const response = await axios.get<Servico>(`${apiBaseUrl}/service/${id}`);
    return response.data;
  } catch (error: any) {
    console.log("error message: ", error.message);
  }
};

