import axios, { AxiosResponse } from "axios";

const apiBaseUrl = process.env.REACT_APP_API_BASE_URL || "http://localhost:5254/api";

interface ApiErrorResponse {
  status: number;
  errors: any;
}

export const createAdAPI = async (adType: "product" | "service", data: any): Promise<AxiosResponse | ApiErrorResponse> => {
  try {
    const url = `${apiBaseUrl}/${adType}`;
    const response = await axios.post(url, data, {
      headers: {
        "Content-Type": "application/json",
      },
    });
    return response;
  } catch (error: any) {
    if (error.response) {
      if (error.response.status === 400 && error.response.data.errors) {
        return { 
          status: 400, 
          errors: error.response.data.errors 
        };
      }
    }
    throw new Error("Erro ao conectar com o servidor.");
  }
};