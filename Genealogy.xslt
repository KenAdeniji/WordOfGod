<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<!-- 
 Created:  20030721.
-->

<xsl:output method="html" indent="no" />
 <xsl:variable
  name="genealogy"
 />
 <xsl:template match="/">
  <html>
   <body>
    <table align="center" border="1">
     <theader>
      <tr align="center"><td colspan="3">
        Genealogy
        (
         <a target="_blank" href="http://bible.crosswalk.com/OnlineStudyBible/bible.cgi?new=1&amp;word=Judges+2%3A10%2C+Matthew+1%3A1%2C+Matthew+1%3A17%2C+Jude+1%3A14&amp;section=0&amp;version=nkj&amp;language=en">
          Judges 2:10, Matthew 1:1, Matthew 1:17, Jude 1:14
         </a>
        )
      </td></tr>
      <tr align="center"><td colspan="3">
      <a target="_blank" href="http://bible.crosswalk.com/OnlineStudyBible/bible.cgi?new=1&amp;word=John+17%3A11%2C+John+17%3A21-26&amp;section=0&amp;version=nkj&amp;language=en">
      One, Father in Me, I in You, one in Us 
      (
       John 17:11, John 17:21-26
      )
      </a>
      </td></tr> 
      <tr align="center">
       <td>Sign</td>
       <td>Actor</td>       
       <td>ScriptureReference</td>
      </tr>
     </theader>     
     <tbody>
      <xsl:apply-templates select="/Genealogy/Genealogy">
       <xsl:sort select="Genealogy" data-type="text" order="ascending" case-order="lower-first"/>
       <xsl:sort select="Sign" data-type="number" order="ascending" case-order="lower-first"/>
       <xsl:sort select="position()" data-type="number" order="ascending" case-order="lower-first"/> 
      </xsl:apply-templates>
     </tbody>
    </table>
  </body>
 </html>
 </xsl:template>

 <xsl:template match="/Genealogy/Genealogy">
 
  <!--
  <xsl:if test="Genealogy!=$genealogy">
   <tr align="center">
    <td colspan="3">
     <xsl:variable name="genealogy" select="Genealogy"/>
     Genealogy of <xsl:value-of select="$genealogy"/>
    </td>
   </tr>
  </xsl:if> 
  -->
  
  <tr align="center">
   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="Sign"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="Sign"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>
   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="ManNamed"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="ManNamed"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>
   <td>
    <xsl:choose>
     <xsl:when test="ScriptureReferenceURI!=''">
      <a target="_blank" href="{ScriptureReferenceURI}">
       <xsl:value-of select="ScriptureReference"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <xsl:value-of select="ScriptureReference"/>
     </xsl:otherwise>
    </xsl:choose>
   </td>
   <td>
    <xsl:value-of select="Commentary"/>
   </td>
  </tr>
 </xsl:template>
 
</xsl:stylesheet>

<!--
Legal filter operators are:
 =    (equal) 
 !=   (not equal) 
 &lt; less than 
 &gt; greater than
-->

<!--
HTML Special Entities
Character   Meaning        Entity   Numeric
<           Less than      &lt;     &#60;
>           Greater than   &gt;     &#62;
&           Ampersand      &amp;    &#38;
'           Apostrophe     &apos;   &#39;
"           Quote          &quot;   &#34;
-->
