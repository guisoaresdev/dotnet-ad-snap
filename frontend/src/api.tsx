import axios from "axios";
import {
  Produto,
  Servico
} from "./company";

export const getProdutos = async () => {
  try {
    const response = await axios.get<Produto[]>(`${process.env.REACT_APP_API_URL}/product`);
    return response.data;
  } catch (error: any) {
    console.log("error message: ", error.message);
  }
};

export const getServicos = async () => {
  try {
    const response = await axios.get<Servico[]>(`${process.env.REACT_APP_API_URL}/service`);
    return response.data;
  } catch (error: any) {
    console.log("error message: ", error.message);
  }
};

export const getProdutoById = async (id: string) => {
  try {
    const response = await axios.get<Produto>(`${process.env.REACT_APP_API_URL}/product/${id}`);
    return response.data;
  } catch (error: any) {
    console.log("error message: ", error.message);
  }
};

export const getServicoById = async (id: string) => {
  try {
    const response = await axios.get<Servico>(`${process.env.REACT_APP_API_URL}/service/${id}`);
    return response.data;
  } catch (error: any) {
    console.log("error message: ", error.message);
  }
};

