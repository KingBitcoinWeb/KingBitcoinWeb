package API_Details;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;
import java.util.HashMap;
import java.util.logging.Level;
import java.util.logging.Logger;

import com.google.gson.Gson;

public class FAB_Get_ValorAtual_BTC {

	public static void main(String[] args) {
        try {
            String url = "https://www.mercadobitcoin.net/api/BTC/ticker/";

            HttpURLConnection conn = (HttpURLConnection) new URL(url).openConnection();

            conn.setRequestMethod("GET");
            conn.setRequestProperty("Accept", "application/json");

            if (conn.getResponseCode() != 200) {
                System.out.println("Erro " + conn.getResponseCode() + " ao obter dados da URL " + url);
            }

            BufferedReader br = new BufferedReader(new InputStreamReader((conn.getInputStream())));

            String output = "";
            String line;
            while ((line = br.readLine()) != null) {
                output += line;
            }

            conn.disconnect();

            Gson gson = new Gson();
            DadosBTC dadosBTC = gson.fromJson(new String(output.getBytes()),DadosBTC.class);
            		//), DadosBTC.class);
            
            System.out.println("Valor BTC: " + dadosBTC.getBuy());

        } catch (IOException ex) {
            Logger.getLogger(FAB_Get_ValorAtual_BTC.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

}
